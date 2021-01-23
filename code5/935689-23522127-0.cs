    var table = new System.Data.DataTable();
    table.Columns.Add("object_name", typeof(string));
    table.Columns.Add("object_id", typeof(int));
    table.Columns.Add("object_xpath", typeof(string));
    table.Columns.Add("time", typeof(DateTime));
    foreach (var pair in webidsAndXPaths)
    {
        table.Rows.Add(objectName, pair.Key, pair.Value, dt);
    }
