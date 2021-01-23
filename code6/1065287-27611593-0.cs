            var qry1 = (from m in Db.Metrics
                        join i in Db.Impressions on m.MetricId equals i.MetricId
                        //where 
                        group m by m.CountryCode into grp
                        select new
                        {
                            CountryCode = grp.Key,
                            Impressions = grp.Count()
                        });
            var qry2 = (from m in Db.Metrics
                        join c in Db.Conversions on m.MetricId equals c.MetricId
                        //where 
                        group m by m.CountryCode into grp
                        select new
                        {
                            CountryCode = grp.Key,
                            Conversions = grp.Count()
                        });
            var result = (from x in qry1
                          join y in qry2 on x.CountryCode equals y.CountryCode
                          select new
                          {
                              CountryCode = x.CountryCode,
                              Impressions = x.Impressions,
                              Conversions = y.Conversions
                          });
            var lst = result.ToList();
