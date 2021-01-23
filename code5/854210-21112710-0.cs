    var aaData = PatList.Select(d => (new string[] { 
            d.Username,
            d.Address1,
            d.Age.ToString()
        }.Union(d.Columns.Select(c => c.ColumnHeader))).ToArray()
    ).ToArray();
