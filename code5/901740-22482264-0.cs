    .GroupBy(x => new { x.OA, x.CD, })
    .Select(g => new
    {
        g.Key.OA,
        g.Key.CD,
        g.Select(item => item.PDate).Distinct().Count(),
    })
