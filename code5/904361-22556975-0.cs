    var orderitems =
                       from orderItem in db.Order_ProductItem
                       join style in db.Products_Styles on orderItem.Style equals style.Index
                       where orderItem.SalesOrderID == salesOrderId && (orderItem.IsDeleted==null || orderItem.IsDeleted.Value == false)
                       group new { orderItem, style } by orderItem.FrameNo into grp
                       select new OrderItemModel
                       {
                           FrameNo = grp.Key,
                           //Count = grp.Select(x => x.orderItem.FrameNo).Count(),
                           TotalCost = grp.Sum(x => x.orderItem.CostPrice),
                           OverAllWidth = grp.FirstOrDefault(x => x.orderItem.HardwareType == 3).orderItem.OverallWidth,
                           OverAllHeight = grp.FirstOrDefault(x => x.orderItem.HardwareType == 3).orderItem.OverallHeight,
                           Name = grp.FirstOrDefault().style.Name,//.FirstOrDefault(),
                           ImagePath = grp.FirstOrDefault().style.External_Image_Path//x => x.style.External_Image_Path)//.FirstOrDefault()
                       };
                    //var count = orderitems.Count();
    
    
                    var orders =  orderitems.ToList();
