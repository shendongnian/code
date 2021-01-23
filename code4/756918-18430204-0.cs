    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("col1", typeof(int)));
    dt.Columns.Add(new DataColumn("col2", typeof(int)));
    dt.Columns.Add(new DataColumn("col3", typeof(int)));
    dt.Columns.Add(new DataColumn("col4", typeof(bool)));
    
    var distinctRows = from r in dt.AsEnumerable()
                       group r by new { col1=r["col1"], col2=r["col2"], col3=r["col3"]}
                       into g
                       select g.First();
    
    foreach (var distinctRow in distinctRows)
    {
       distinctRow["col4"] = "dup";
    }
