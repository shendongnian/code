    var innerQuery = (from t in VDC.SURVEY_VISITORS
                      group t by new
                      {
                        t.FROM_COUNTRY
                      } into g
                      orderby
                      g.Count() descending
                      select new
                      {
                        VisitorCount = (Int64?)g.Count(),
                        Country = g.Key.FROM_COUNTRY
                      }).FirstOrDefault();
    var result = (from xx in VDC.SURVEY_VISITORS
                                      where ((innerQuery.Country.Contains(xx.FROM_COUNTRY)) && xx.TEMPLATE_ID == RecentBlastedTemplate.TEMPLATE_ID)                                  
                                      select new
                                          {
                                              xx.FROM_COUNTRY,
                                              xx.FROM_EMAILID
                                          }).Distinct().ToList();
