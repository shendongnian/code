    var grouped = debits
        .GroupBy(d => new { Code = d.Code, Length = d.Length })
        .Select(g => new Debit() {
            Code = g.Code,
            Length = g.Length,
            Qte = g.Sum(x => x.Qte),
            Position = string.Join(", ", g.Select(x => x.Position).Distinct())
        });
