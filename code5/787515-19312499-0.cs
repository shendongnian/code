        public ActionResult ContactsListRead([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<ContactsModel.ContactsGrid> query = ContactsModel.ContactsService.Get();
            int count = ContactsModel.ContactsService.GetCount();
            query = AjaxCustomBindingExtensions.ApplyOrdersFiltering(query, request.Filters, out count, count);
            query = AjaxCustomBindingExtensions.ApplyOrdersSorting(query, request.Groups, request.Sorts);
            query = AjaxCustomBindingExtensions.ApplyOrdersPaging(query, request.Page, request.PageSize);
            IEnumerable data = AjaxCustomBindingExtensions.ApplyOrdersGrouping(query, request.Groups);
            var result = new DataSourceResult()
            {
                Data = data,
                Total = count
            };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
