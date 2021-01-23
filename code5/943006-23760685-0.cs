    var query  = list.GroupBy(r => new { r.SiteId, r.MetricMonth, r.MetricYear })
                .Select(grp => new
                {
                    SiteId = grp.Key.SiteId, 
                    MetricMonth = grp.Key.MetricMonth, 
                    MetricYear = grp.Key.MetricYear, 
                    TotalLeads = grp.Sum(r=> r.TotalLeads), 
                    TotalEmails = grp.Sum(r=> r.TotalEmails), 
                    UniqueVisits = grp.Sum(r=> r.UniqueVisits), 
                    DeviceCategory = String.Join(",", grp.Select(r=> r.DeviceCategory)),
                });
