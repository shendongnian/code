    // Create and populate data tables
    DataTable dataTable1 = new DataTable();
    dataTable1.Columns.Add("Name", typeof(string));
    DataRow row1 = dataTable1.NewRow();
    row1["Name"] = "Inam";
    DataRow row2 = dataTable1.NewRow();
    row2["Name"] = "Sohan";
    dataTable1.Rows.Add(row1);
    dataTable1.Rows.Add(row2);
    DataTable dataTable2 = new DataTable();
    dataTable2.Columns.Add("Name", typeof(string));
    DataRow row3 = dataTable2.NewRow();
    row3["Name"] = "Ranjan";
    DataRow row4 = dataTable2.NewRow();
    row4["Name"] = "Inam";
    DataRow row5 = dataTable2.NewRow();
    row5["Name"] = "Sohan";
    dataTable2.Rows.Add(row3);
    dataTable2.Rows.Add(row4);
    dataTable2.Rows.Add(row5);
    // Loop through rows in first table
    foreach (DataRow row in dataTable1.Rows)
    {
        int rowIndexInSecondTable = 0;
        // Loop through rows in second table
        for (int i = 0; i < dataTable2.Rows.Count; i++)
        {
            // Check if the column values are the same
            if (row["Name"] == dataTable2.Rows[i]["Name"])
            {
                // Set the current index and break to stop further processing
                rowIndexInSecondTable = i;
                break;
            }
        }
    
        // The index of the row in the second table is now stored in the rowIndexInSecondTable variable, use it as needed, for example, writing to the console
        Console.WriteLine("Row with name '" + row["Name"] + "' found at index " + rowIndexInSecondTable.ToString());
    }
