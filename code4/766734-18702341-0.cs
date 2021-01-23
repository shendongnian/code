    var items = ctx.Item.Select(i => new ItemAttribute { 
        r = i.R
    ,   n = i.N
    ,   s = i.S
    })
    .GroupBy(i => new { i.Color, i.Category })
    .OrderBy(p => p.Key.Color)
    .ThenBy(p => p.Key.Category);
