    var result = db.Transactions
             .Where(r => r.Id == 123)
             .GroupBy(r => new { r.Id, r.Location} )
             .Select(grp => new
             {
                 Id = grp.Key.Id,
                 Location = grp.Key.Location,
                 Quantity = grp.Sum(t=> t.TransactionType == 2 ? t.Quantity * -1 : t.Quantity),
             });
