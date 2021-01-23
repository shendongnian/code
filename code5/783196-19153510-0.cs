    var query = (from xx in VDC.SURVEY_VISITORS
                 where xx.TEMPLATE_ID == tempid
                 group xx by new { xx.FROM_COUNTRY } into g
                 select new
                 {
                    Count = g.Select(act => act.FROM_EMAILID).Distinct().Count(),
                    g.Key.FROM_COUNTRY
                 }).Take(5).OrderByDescending(x => x.Count);
