            var groups = trades.GroupBy(trade => trade.Times, new TimeArrayComparer());
            var result = groups.Select(grouping =>
            {
                var trade = grouping.First();
                trade.EndDate = grouping.Last().EndDate;
                return trade;
            });
