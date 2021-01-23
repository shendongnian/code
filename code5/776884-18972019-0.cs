    // get all columns to array 
    var columns  = yourDataTable.Columns.Cast<DataColumn>().ToArray();
    
    foreach(var col in columns) {
        // check column values for null 
        if (yourDataTable.AsEnumerable().All(dr => dr.IsNull(col)))
        {
             // remove all null value columns 
             yourDataTable.Columns.Remove(col);
        }
    
    }
