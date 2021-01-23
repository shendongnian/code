    private void SetupGridView()
    {
        var dt = GetDataTable();
        // add addition column
        dt.Columns.Add(new DataColumn() {ColumnName = "Id2", DataType = typeof (int)});
        // add additional data
        for (var i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["Id2"] = Convert.ToInt32(dt.Rows[i][0])*2;
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
