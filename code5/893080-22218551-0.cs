    GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
    checkBoxColumn.DataType = typeof(int);
    checkBoxColumn.Name = "DiscontinuedColumn";
    checkBoxColumn.FieldName = "Discontinued";
    checkBoxColumn.HeaderText = "Discontinued?";
    radGridView1.MasterTemplate.Columns.Add(checkBoxColumn);
