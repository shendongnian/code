    var myTable = new DataTable();
    myTable.Columns.Add("Column One");
    myTable.Columns.Add("Column Two");
    var newRow = myTable.NewRow();
    newRow[0] = 11111;
    newRow[1] = 22222;
    myTable.Rows.Add(newRow);
    var newRow2 = myTable.NewRow();
    newRow2 [0] = 33333;
    newRow2 [1] = 44444;
    myTable.Rows.Add(newRow2);
    
    
    foreach (var row in myTable.AsEnumerable())
    {
        foreach (DataColumn column in myTable.Columns)
        {
            Console.WriteLine("Column {0}, Row {1}, Value {2}", column.ColumnName, myTable.Rows.IndexOf(row), row[column]);
        }
    }
