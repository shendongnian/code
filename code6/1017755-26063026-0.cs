    var query = source.GroupBy(
        x => x.A,
        (a, aGroup) => new
        {
            A = a,
            Items = aGroup.GroupBy(
                x => x.B,
                (b, bGroup) => new
                {
                    B = b,
                    Items = bGroup
                })
        });
