    //create datatable and columns,
    DataTable dtable = new DataTable();
    dtable.Columns.Add(new DataColumn("Column 1"));
    dtable.Columns.Add(new DataColumn("Column 2"));
     
    //simple way create object for rowvalues here i have given only 2 add as per your requirement
    object[] RowValues = { "", "" };
     
    //assign values into row object
    RowValues[0] = "your value 1";
    RowValues[1] = "your value 2";
     
    //create new data row
    DataRow dRow;
    dRow = dtable.Rows.Add(RowValues);
    dtable.AcceptChanges();
     
    //now bind datatable to gridview... 
    gridview.datasource=dbtable;
    gridview.databind();
