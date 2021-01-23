    account.Transactions
           .SelectMany(t => t.Tags.Select(tag => new { t.Amount, tag.Title }))
           .GroupBy(x => x.Title)
           .Select(g => new {
              TagName = g.Key,
              Sum = g.Sum(x => x.Amount)
           });
