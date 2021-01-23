    var nTables = 0;
    System.Diagnostics.Debug.WriteLine("Tables in the database");
    foreach (var mapping in con.TableMappings)
    {
        System.Diagnostics.Debug.WriteLine(mapping.TableName);
        nTables++;
    }
    System.Diagnostics.Debug.WriteLine("{0} tables in total", nTables);
