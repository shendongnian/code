    DataSet newTable = new DataSet();
    newTable.ReadXml(@"XMLFile1.xml");
    
    foreach(DataTable table in newTable.Tables)
    {
        Console.WriteLine(table.TableName);
    
        foreach(DataColumn column in table.Columns)
        {
            Console.WriteLine("  " + column.ColumnName);
        }
    }
