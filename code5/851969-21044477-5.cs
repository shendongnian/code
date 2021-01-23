    account.Transactions
           .SelectMany(t => t.Tags.Select(tag => new { t.Amount, tag.Title }))
           .GroupBy(tagAmount => tagAmount.Title)
           .Select(g => new {
              TagName = g.Key,
              Sum = g.Sum(tagAmount => tagAmount.Amount)
           });
