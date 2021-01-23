    dt.AsEnumerable()
        .GroupBy(r => new { Col1 = r["Col1"], Col2 = r["Col2"] })
        .Select(g =>
        {
            var row = dt.NewRow();
    
            row["PK"] = g.Min(r => r.Field<int>("PK"));
            row["Col1"] = g.Key.Col1;
            row["Col2"] = g.Key.Col2;
    
            return row;
    
        })
        .CopyToDataTable();
