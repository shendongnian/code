    DataTable dt = view.GetReport();
    Type dateType = typeof(DateTime);
    foreach (DataColumn column in dt.Columns)
    {
        BoundField f =  new BoundField();
        f.HeaderText = column.ColumnName;
        f.DataField = column.ColumnName;
        if(column.DataType == dateType)
            f.DataFormatString = "{0:d}"; // Or whatever
        gvReport.Columns.Add(f);
    }
    gvReport.DataSource = dt;
    gvReport.DataBind();
