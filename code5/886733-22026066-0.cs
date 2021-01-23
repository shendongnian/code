    // Setup a sample table to match yours
    DataTable myDataTable = new DataTable();
    myDataTable.Columns.Add("id", typeof(string));
    // Add some values to the table
    myDataTable.Rows.Add("2012/12");
    myDataTable.Rows.Add("2012/05");
    myDataTable.Rows.Add("2010/04");
    myDataTable.Rows.Add("2010/05");
    myDataTable.Rows.Add("2013/08");
    // Add a helper column with DateTime format
    myDataTable.Columns.Add("date",typeof(DateTime));
    // Convert all IDs to dates and store them in the helper column
    foreach (DataRow row in myDataTable.Rows) row["date"] = Convert.ToDateTime(row["id"]);
    // Create a view to match yours, sorting by date now instead of id
    DataView view = myDataTable.DefaultView;
    view.Sort = "date DESC";
    //myGrid.DataSource = view;
    // Write my output
     foreach (DataRow row in view.ToTable().Rows) Console.WriteLine(row["id"]);
