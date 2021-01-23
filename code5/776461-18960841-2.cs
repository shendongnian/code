    var grouping = Vaults
        .GroupBy(v => new MultipartKey<Item>(v.Contents.Items))
        .Select(g => new {
            Items = g.First().Contents.Items
        ,   Vaults = g.ToList()
        });
        foreach (var g in grouping) {
            Console.WriteLine("{0} ---- {1}"
            ,   string.Join(",", g.Items.Select(i=>i.Id))
            ,   string.Join(",", g.Vaults.Select(v => v.Id))
            );
        }
