    decimal currentTotal = 0;
    var query = test
                .OrderBy(i => i.Date)
                .Select(i => new
                {
                        Date = i.Date,
                        Amount = i.Amount
                })
                // Above lines executed on SQL
                .AsEnumerable()
                // Below lines executed locally
                .Select(i =>
                {
                    currentTotal += i.Amount;
                    return new
                    {
                        Date = i.Date,
                        Amount = i.Amount,
                        RunningTotal = currentTotal
                    };
                }
            );
