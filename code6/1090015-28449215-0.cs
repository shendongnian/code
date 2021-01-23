    var date = new Date(2015, 2, 28).AddDays(1);
    var query = from account in context.Accounts
                where account.CreatedAt < date
                where account.accountType == "business"
                group account by 
                       SqlFunctions.DateDiff(
                                "Month", 
                                 SqlFunctions.DateAdd(
                                       "Hour", 11, a.createdAt), 
                                 date)
                into g
                where g.Key < 12
                order by g.Key ascending
                select new 
                {
                    MonthsAgo = g.Key,
                    Count = g.Count(),
                };
