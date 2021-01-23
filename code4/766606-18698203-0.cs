    var query = (from p in Productions
    join t in MaterialTransactions
        on p.Prodn_ID equals t.Prodn_ID
    where p.WO_ID == 2345
    orderby p.Date descending
    select new  {
        Id = p.Prodn_ID,
        Date = p.Date,
        Line1 = p.ProdLine.Factory.Factory_No,
        Line2 = p.ProdLine.ProdLine_No,
        Qty = p.Qty,
        Wgt = (double)p.ActWgt,
        Speed = (double)p.ActSpeed,
        MaterialUsed = t.Material.Name
    })
    .AsEnumerable()
    // This is where the db-stuff stops, and the in-memory stuff begins
    .Select(p => new {
        p.Id,
        p.Date,
        Line = p.Line1 + '/' + p.Line2.ToString(),
        p.Qty,
        p.Wgt,
        p.Speed,
        p.MaterialUsed
    });
    var result = query.ToList();
