    // context.MyTable is an IQueryable<MyTable>
    var query = from t in context.MyTable
                group t by t.Code into grp
                select
                new {
                    Code = grp.Key,
                    Jan = grp.Sum(x => x.Month == 1 ? x.Days : 0),
                };
