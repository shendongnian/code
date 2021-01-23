    var quantities
        = db.Stocks.Find(id).Trades
                   .GroupBy(x => x.Price.Date)
                   .Select(x => new
                                {
                                    date = x.Key.Subtract(unix).TotalMilliseconds,
                                    value = x.Sum(y => y.Quantity)
                                })
                   .ToList();
