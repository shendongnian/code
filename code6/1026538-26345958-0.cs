    var results = db.Orders
                .GroupBy(x => new
                {
                    Completed = SqlFunctions.DatePart("week", x.Completed)
                })
                .Select(x=>x.Sum(y => y.Total))
                .ToList();
