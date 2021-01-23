    var criteria = new List<string>();
    criteria.Add("abc");
    criteria.Add("def");
    criteria.Add("ghic");
    //etc
    var filteredRows = myDataTable.AsEnumerable()
        .Where(row => !criteria.Contains(row["colName"].ToString()));
