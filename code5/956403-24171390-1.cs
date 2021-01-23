    var data = (
        from p in _db.Listings_Audit
        group p by
            new
            {
                Column1 = (int)SqlFunctions.DatePart("wk", p.audit_date),
                Column2 = (int)SqlFunctions.DatePart("year", p.audit_date)
            }
        into g
        select
            new
            {
                week = g.Key.Column1,
                year = g.Key.Column2,
                startOfWeek =
                    EntityFunctions.AddDays(
                        EntityFunctions.CreateDateTime(g.Key.Column2, 1, 1, 0, 0, 0),
                        (7 * (g.Key.Column1 - 1))),
                endOfWeek =
                    EntityFunctions.AddDays(
                        EntityFunctions.CreateDateTime(g.Key.Column2, 1, 1, 0, 0, 0),
                        (7 * (g.Key.Column1))),
                updatedRecCnt = g.Count(p => p.CreatedDate != null),
            }).OrderBy(g => g.startOfWeek).ToList();
