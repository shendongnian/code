    var results = Table3_Collection
        .Where(i => column4s.Contains(i.Column4))
        .Join(Table1_Collection, i => i.Column3, i => i.Column3, (i, j) => j)
        .Join(Table2_Collection, i => i.Column1, i => i.Column1, (i, j) => i)
        .Distinct(comparer);
