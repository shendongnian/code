    var groups = costPageRows
            .GroupBy(x => new CostPageParent()
            {
                CostPage = x.CostPage,
                Description = x.Description,
                BillTypeDirect =  x.BillTypeDirect,
                BillTypeWarehouse = x.BillTypeWarehouse,
                OrderType = x.OrderType,
                Vendor = x.Vendor
            }, new CostPageParentEqualityComparer())
        .Select(y => new CostPageSelection
            {
                CostPageParent = y.Key,
                ChildItems = y.Select(i => 
                    new ItemChild()
                    { 
                        BrandCode = i.BrandCode,
                        ItemDescription = i.ItemDescription,
                        ItemID = i.ItemID,
                        PackSize = i.PackSize
                    })
                    .ToList()
            })
        .ToList();
