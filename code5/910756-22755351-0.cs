    //Create & Configure DataTable
    var dt = new DataTable();
    dt.Columns.Add("Name Column", typeof(string));
    dt.Columns.Add("Name Column", typeof(int));
    //Your IEnumerable Query 
    var qu = from p in DBop.SampleTBLs
             select new object[] {p.SomeProperty, p.SomeProperty2};
    //Add results to DataTable
    foreach (var item in qu)
        dt.Rows.Add(item);
