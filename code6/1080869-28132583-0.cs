      OleDbConnection cn = new OleDbConnection();
      OleDbCommand cmd = new OleDbCommand();
      DataTable schemaTable;
      OleDbDataReader myReader;
      //Open a connection to the SQL Server Northwind database.
      cn.ConnectionString = "...";
      cn.Open();
      //Retrieve records from the Employees table into a DataReader.
      cmd.Connection = cn;
      cmd.CommandText = "SELECT * FROM Employees";
      myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
      //Retrieve column schema into a DataTable.
      schemaTable = myReader.GetSchemaTable();
      var myAutoIncrements = schemaTable.Rows.Cast<DataRow>().Where(
                  myField => myField["IsAutoIncrement"].ToString() == "True");
      foreach (var myAutoInc in myAutoIncrements)
      {
          Console.WriteLine((myAutoInc[0]));
      }
      Console.ReadLine();
      //Always close the DataReader and connection.
      myReader.Close();
      cn.Close();
