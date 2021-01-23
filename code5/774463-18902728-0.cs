    DataTable dt2 = new DataTable();
    // Create temporary list to sort rows by int value.
    List<DataRow> rows = new List<DataRow>();
    foreach (DataRow row in table.Rows)
    {
       rows.Add(row);    
    }
    
    // Sort list in ascending order
    rows.Sort(delegate(DataRow row1, DataRow row2)
         {
             return ((int)row1["CalculatedPriceWithNoSymbol"])
                      .CompareTo(((int)row2["CalculatedPriceWithNoSymbol"]));
         });
    
    // Add sorted rows back to datatable.
    foreach (DataRow row in rows)
    {
        dt2.Rows.Add(row.ItemArray);
    }
    
    DataList1.DataSource = dt2;
    DataList1.DataBind();
