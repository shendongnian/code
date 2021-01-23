    account.Transactions
           .SelectMany(t => t.Tags.Select(tag => new { t.Amount, tag }))
           .GroupBy(x => x.tag)
           .Select(g => new {
              TagName = g.Key,
              Sum = g.Sum(x => x.Amount)
           });
