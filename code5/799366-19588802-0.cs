    var q = from a in odc.AVCs
            select new AVCListItem
            {
                Id = a.Id,
                Name = a.Name,
                Address = a.Address,
                Count = yellows.Where(o => o.AVCId == a.Id).Count()
            };
