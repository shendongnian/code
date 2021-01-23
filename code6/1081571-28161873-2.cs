    OleDbConnection cn = new OleDbConnection();
    OleDbCommand cmd = new OleDbCommand();
    //Open a connection to the SQL Server Northwind database.
    // This is the sample DB I have used in my example.
    cn.ConnectionString = "Provider=SQLOLEDB;Data Source=SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
    cn.Open();
    //Retrieve records from the Employees table into a DataReader.
    cmd.Connection = cn;
    cmd.CommandText = "SELECT * FROM Employees";
    //Retrieve column schema into a constraints.
    var schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Check_Constraints,null);
    //For each field in the table...
    foreach (DataRow myField in schemaTable.Rows)
    {
        //For each property of the field...
        foreach (DataColumn myProperty in schemaTable.Columns)
        {
            //Display the field name and value.
            Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
        }
        Console.WriteLine();
        //Pause.
    }
    Console.WriteLine("Done");
    Console.ReadLine();
    //Always close the DataReader and connection.
    cn.Close();
