    var query = dataSet.Tables[tableOne].AsEnumerable()
        .Select(r => new { ident = r.Field<string>("ident"), Pos = r.Field<int>("Pos") })
        .Concat(dataSet.Tables[tableTwo].AsEnumerable()
        .Select(r => new { ident = r.Field<string>("ident"), Pos = r.Field<int>("Pos") }))
        .OrderBy(x => x.Pos); 
