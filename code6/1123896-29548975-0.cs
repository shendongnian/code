    var query = from d in analyticsData
                group d by new { d.Webproperty, d.DeviceModel }
                into g
                select new 
                {
                    g.Webproperty,
                    g.DeviceModel,
                    Total = g.Sum(it => it.PageViews)
                };
    var result = query.ToList();
