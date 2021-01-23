    var result = (from o in this._database.MyTable
                  group o by o.CompanyId into grouped
                  select new {
                                grouped.Key,
                                Count = grouped.Select(c => c.UkDate).Distinct().Count()
                             } into filter
                     where filter.Count > 1
                     join a in this._database.MyTable on filter.Key equals a.CompanyID
                     select new { a.CompanyID, a.UkDate}
                 ).ToList();
