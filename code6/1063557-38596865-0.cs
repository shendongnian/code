    using (OleDbConnection conn = new OleDbConnection(connectionString)) {
        conn.Open();
        string SheetName = "Sheet1";
        string TableRange = "A1:P{0}";
        // count the number of non empty rows
        using (var cmd1 = new OleDbCommand(null, conn)) {
            cmd1.CommandText = String.Format(
              "SELECT COUNT(*) FROM [{0}$] WHERE ID IS NOT NULL;"
              , SheetName);
            TableRange = string.Format(TableRange, (int)cmd1.ExecuteScalar() + 1);
        }
        // insert a new record
        using (var cmd2 = new OleDbCommand(null, conn)) {
            cmd2.CommandText = String.Format(
                "INSERT INTO [{0}${1}] (ID, Title, NTV_DB, Type) VALUES(7959, 8,'e','Type1');"
                , SheetName, TableRange);
            cmd2.ExecuteNonQuery();
        }
    }
