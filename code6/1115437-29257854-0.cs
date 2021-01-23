    // We iterate through the DataTable rows.
    foreach(DataRow row in theDataTable .Rows)
    {
        // We get the value of Column3 for the current row and replace 
        // the - with empty.
        string value = row.Field<string>("Column3").Replace("-","");
   
        // Then we update the value.
        row.SetField("Column3", value);
    }
