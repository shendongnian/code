    var orderGroups = costPageRows
     .GroupBy(x => new { 
         x.CostPage, 
         x.Description, 
         x.BillTypeDirect,
         x.BillTypeWarehouse,
         x.OrderType,
         x.Vendor,
         x.VendorID 
     })
     // The following statement is basically a let statement from query expression
     .Select(y => new {
          y, 
          first = y.First()
     })
     .Select(z => new CostPageSelection {
          new CostPageParent { 
              z.first.CostPage, 
              ... // other props 
              ChildItems = z.Select(i => new ItemChild {
                  i.ItemID,
                  ... // other props 
              }).ToList()
     })
     .ToList();
