    var data = (from p in _db.Listings_Audit
            where p.audit_type == "U"
            where p.audit_date.Value.Year == 2014
            group p by new
            {
                Column1 = (int?) SqlFunctions.DatePart("wk", p.audit_date),
                Column2 = (int?) SqlFunctions.DatePart("year", p.audit_date)
            }
            into g
            select new
            {
                week = g.Key.Column1,
                updatedRecCnt = g.Count(p => p.audit_date != null),
                startOfWeek = p.audit_date.Date.AddDays(-(int)date.DayOfWeek)
                endOfWeek = p.audit_date.Date.AddDays(-(int)date.DayOfWeek).AddDays(7)
            }).OrderBy(g=>g.week).ToList();
