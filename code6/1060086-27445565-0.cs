     public ActionResult CustomAjaxBinding_Read([DataSourceRequest] DataSourceRequest request)
        {
            var dataContext = new SampleEntities();
            // Convert to view model to avoid JSON serialization problems due to circular references.
            IQueryable<OrderViewModel> orders = dataContext.Orders.Select(o => new OrderViewModel
            {
                OrderID = o.OrderID,
                ShipCity = o.ShipCity,
                ShipCountry = o.ShipCountry,
                ShipName = o.ShipName
            });
            orders = orders.ApplyOrdersFiltering(request.Filters);
            var total = orders.Count();
            orders = orders.ApplyOrdersSorting(request.Groups, request.Sorts);
            if (!request.Sorts.Any())
            {
                // Entity Framework doesn't support paging on unsorted data.
                orders = orders.OrderBy(o => o.OrderID);
            }
            orders = orders.ApplyOrdersPaging(request.Page, request.PageSize);
            IEnumerable data = orders.ApplyOrdersGrouping(request.Groups);
            var result = new DataSourceResult()
            {
                Data = data,
                Total = total
            };
            return Json(result);
        }
