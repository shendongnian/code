    var resultList = Table2
                .Where(x => x.DateTime > begDate && x.DateTime < endDate)
                .Join(Table1, t2 => t2.AccountId, t1 => t1.Id,
                    (t2, t1) => new { t2.AccountId, t1.Description })
                .GroupBy(x => x.AccountId)
                .Select(g => new { Group = g, Charges = g.Count() })
                .OrderByDescending(g => g.Charges)
                .SelectMany(g => g.Group.Select(x => new { x.Description, x.AccountId, g.Charges }))
                .ToList();
