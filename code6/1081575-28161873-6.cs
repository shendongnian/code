    //Open a connection to the SQL Server Northwind database.
    cn.ConnectionString = "Provider=SQLOLEDB;Data Source=EINSTEINIUM\\SQL2014EXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;Encrypt=False;TrustServerCertificate=False";
    cn.Open();
    //Retrieve records from the Employees table into a DataReader.
    cmd.Connection = cn;
    cmd.CommandText = "SELECT * FROM Employees";
    myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
    //Retrieve column schema into a DataTable.
    schemaTable = myReader.GetSchemaTable();
    // ++ Added ++
    var listOfTableFields = new List<string>();
    //For each field in the table...
    foreach (DataRow myField in schemaTable.Rows)
    {
        //For each property of the field...
        foreach (DataColumn myProperty in schemaTable.Columns)
        {
            //Display the field name and value.
            Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
            // ++ Added ++
            if (myProperty.ColumnName == "ColumnName")
            {
                listOfTableFields.Add(myField[myProperty].ToString());
            }
        }
        Console.WriteLine();
        //Pause.
    }
    //Always close the DataReader and connection.
    myReader.Close();
    cn.Close();
    // ++ Added ++
    Console.WriteLine("List of fields in Employees table.");
    // List of Fields in the Employees table.
    foreach (var fieldName in listOfTableFields)
    {
        Console.WriteLine(fieldName);
    }
    Console.ReadLine();
