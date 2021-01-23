    // Setup a sample table to match yours
    DataTable myDataTable = new DataTable();
    myDataTable.Columns.Add("id", typeof(string));
    // Add some values to the table
    myDataTable.Rows.Add("7/14");
    myDataTable.Rows.Add("4/14");
    myDataTable.Rows.Add("8/14");
    myDataTable.Rows.Add("3/14");
    myDataTable.Rows.Add("6/14");
    myDataTable.Rows.Add("10/14");
    myDataTable.Rows.Add("5/14");
    myDataTable.Rows.Add("2/14");
    myDataTable.Rows.Add("9/14");
    myDataTable.Rows.Add("1/14");
    // Add a helper column with 16-bit format based on the values in id
    myDataTable.Columns.Add("helper", typeof(Int16));
    // Convert the value in the id column of each row to a string,
    // then split this string at the '/' and get the first value.
    // Convert this new value to a 16-bit integer,
    // then save it in the helper column.
    foreach (DataRow row in myDataTable.Rows) row["helper"] =
        Convert.ToInt16(row["id"].ToString().Split('/')[0]);
    // Create a view to match yours, sorting by helper column instead of id
    DataView view = myDataTable.DefaultView;
    view.Sort = "helper DESC";
    //myGrid.DataSource = view;
    // Write the output from this view
    foreach (DataRow row in view.ToTable().Rows) Console.WriteLine(row["id"]);
