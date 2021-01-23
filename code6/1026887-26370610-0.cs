    var data = GetData();  // Get all 10 of your columns
    var gridView = new GridView() { Id = "gridView1", AutoGenerateColumns = false };
    foreach(var colName in listColumns)
    {
       gridView.Columns.Add(new BoundField() { DataField = colName });
    }
    gridView.DataSource = data;
    gridView.DataBind();
