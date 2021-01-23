    var results = ctx.Items
        .GroupBy(i => new { i.Color, i.Category })
        .Select(g => new ItemGroup
        {
            color = g.Key.Color,
            category = g.Key.Category
            items = g.Select(i => new ItemAttribute
                    { 
                        r = i.R,
                        n = i.N,
                        s = i.S
                    })
                    .ToArray()
        };
