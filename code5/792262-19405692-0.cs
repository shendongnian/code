    private static void Migrate(string dbConn1, string dbConn2) {
      // DataTable to store your info into
      var table = new DataTable();
      // Modify your SELECT command as needed
      string sqlSelect = "SELECT Col1, Col2, Col3 FROM aTableInOneAccessDatabase ";
      // Notice this uses the connection string to DB1
      using (var cmd = new OleDbCommand(sqlSelect, new OleDbConnection(dbConn1))) {
        cmd.Connection.Open();
        table.Load(cmd.ExecuteReader());
        cmd.Connection.Close();
      }
      // Modify your INSERT command as needed
      string sqlInsert = "INSERT INTO aTableInAnotherAccessDatabase " +
        "(Col1, Col2, Col3) VALUES (@Col1, @Col2, @Col3) ";
      // Notice this uses the connection string to DB2
      using (var cmd = new OleDbCommand(sqlInsert, new OleDbConnection(dbConn2))) {
        // Modify these database parameters to match the signatures in the new table
        cmd.Parameters.Add("@Col1", DbType.Int32);
        cmd.Parameters.Add("@Col2", DbType.String, 50);
        cmd.Parameters.Add("@Col3", DbType.DateTime);
        cmd.Connection.Open();
        foreach (DataRow row in table.Rows) {
          // Fill in each parameter with data from your table's row
          cmd.Parameters["@Col1"].Value = row["Col1"];
          cmd.Parameters["@Col2"].Value = row["Col2"];
          cmd.Parameters["@Col3"].Value = row["Col3"];
          // Insert that data
          cmd.ExecuteNonQuery();
        }
        cmd.Connection.Close();
      }
    }
