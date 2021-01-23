    _dt = new DataTable("Table");
    _dt.Columns.Add("No");
    _dt.Columns.Add("Name");
    DataRow dr = _dt.NewRow();
    for (int i = 1; i <= 10; i++)
    {
        _dt.Rows.Add(""+i, "Name "+ i);                
    }
    dataGrid1.DataContext = _dt;
