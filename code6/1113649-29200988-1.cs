    DataRowCollection table = Select.Execute().Tables[0];
    DataColumnCollection columns = table.Columns;
    foreach(DataColumn col in columns)
    {
        // ...
    }
