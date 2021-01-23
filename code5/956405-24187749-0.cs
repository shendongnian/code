    var data = (from p in _db.Listings_Audit
                        where p.audit_type == "U"
                        where p.audit_date.Value.Year == 2014
                        group p by new
                        {
                            Column1 = (int?)SqlFunctions.DatePart("wk", p.audit_date),
                            Column2 = (int?)SqlFunctions.DatePart("year", p.audit_date)
                        }
                            into g
                            select new
                            {
                                week = g.Key.Column1,
                                updatedRecCnt = g.Count(p => p.audit_date != null),
                                year = g.Key.Column2
                            }).OrderBy(g => g.week).ToList().Select(y => new
                {
                    week = y.week,
                    y.updatedRecCnt,
                    startofweek = new DateTime(y.year.Value, 1, 1).AddDays(-(int)new DateTime(y.year.Value, 1, 1).DayOfWeek).AddDays(y.week.Value * 7 - 7),
                    endofweek = new DateTime(y.year.Value, 1, 1).AddDays(y.week.Value * 7 - 1).AddDays(-(int)new DateTime(y.year.Value, 1, 1).DayOfWeek)
                });
