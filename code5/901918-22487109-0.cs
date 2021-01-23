    var orderitems =
        (from orderItem in Order_ProductItems
         join style in Products_Styles on orderItem.Style equals style.Index
         where orderItem.SalesOrderID == 123
         group new { orderItem, style } by orderItem.FrameNo into grp
         select new
         {
             FrameNo = grp.Key,
             Count = grp.Select(x => x.orderItem.FrameNo).Count(),
             TotalCost = grp.Sum(x => x.orderItem.CostPrice),
             OverAllWidth = grp.Single(x => x.orderItem.HardwareType == 3).OverallHeight,
             Name = grp.style.Name.First(),
             ImagePath = grp.style.External_Image_Path.First()
          };
