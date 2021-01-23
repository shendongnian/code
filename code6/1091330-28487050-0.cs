    IEnumerable<MiniHeader> mini =
        ctx.Details.Include(d => d.MyHeader)
        .GroupBy(d => d.MyHeader)
        .Select(g => new
        {
            Name = g.Key.Name,
            Details = g.Select(i => new { i.Id, i.Text }),
        })
        .AsEnumerable()
        .Select(e => new MiniHeader()
        {
            Name = e.Name,
            DetailTexts = e.Details.ToDictionary(d => d.Id, d => d.Text)
        });
