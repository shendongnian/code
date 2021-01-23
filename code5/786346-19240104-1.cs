    this.currentProduct = obj as Products;
            List<OrderDetails> orderDetailLIst = new XPQuery<OrderDetails>(new Session()).ToList();
            Task.Factory.StartNew(() =>
            {
                var topOrderQuery = (from orderDetail in orderDetailLIst
                                     where
                                         orderDetail.ProductID.ProductID == currentProduct.ProductID
                                     orderby
                                         (orderDetail.UnitPrice * orderDetail.Quantity) descending
                                     select new TopOrder
                                     {
                                         OrderId = orderDetail.OrderID.OrderID,
                                         TotalSales = orderDetail.UnitPrice * orderDetail.Quantity
                                     }).ToList().Take(10);
                DispatcherExt.CurrentDispatcher.BeginInvoke(new Action(() => { this.TopProduct = topOrderQuery; }));
                var orderPerYearQuery = (from order in orderDetailLIst
                                         where order.ProductID.ProductID == currentProduct.ProductID
                                         group order by new { order.OrderID.OrderDate.Year }
                                             into g
                                             select new OrderPYear
                                             {
                                                 TotalOrder = g.Count(),
                                                 OrderYear = g.Key.Year
                                             }).ToList();
                DispatcherExt.CurrentDispatcher.BeginInvoke(new Action(() => { this.OrderPerYear = orderPerYearQuery; }));
                var salesPerYearQuery = (from order in orderDetailLIst
                                         where order.ProductID.ProductID == currentProduct.ProductID
                                         group order by new { order.OrderID.OrderDate.Year }
                                             into g
                                             select new SalesPYear
                                             {
                                                 Sales = g.Sum(p => p.UnitPrice * p.Quantity),
                                                 Year = g.Key.Year
                                             }).ToList();
                DispatcherExt.CurrentDispatcher.BeginInvoke(new Action(() => { this.SalesPerYear = salesPerYearQuery; }));
            });
