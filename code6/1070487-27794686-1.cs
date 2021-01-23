    using(var reader = command.ExecuteReader())
    {
          // This will return false - we don't care, we just want to make sure the schema table is there.
             reader.Read();
             var table = reader.GetSchemaTable();
             foreach (DataColumn column in table.Columns)
             {
                 Console.WriteLine(column.ColumnName);
             }
     }
