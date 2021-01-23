    var table1Dic = table1.AsEnumerable().ToDictionary(dr => dr.Field<int>("ColA1"), dr => dr.Field<string>("ColA2"));
    foreach (var row in table2.AsEnumerable()) {
        var key = (int)row["ColA1"];
        if (table1Dic.ContainsKey(key))
            row.SetField<string>("ColA2", table1Dic[key]);
    }
