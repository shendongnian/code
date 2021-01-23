    string tableName = ValidateTableName(cmdb_ModelStock2.Text); // TODO: Write this!
    DateTime date = DateTime.Parse(cmdb_Date2.Text); // See below
    string sql = "Select N_Serie,MacID from " + tableName + " WHERE Date_Ajout = ?";
    using (var command = new OleDbCommand(sql, conn))
    {
        // Or use type "Date", perhaps... but that would be more appropriate
        // with a range. The name doesn't matter using OLE, which uses positional
        // parameters.
        command.Parameters.Add("Date", OleDbType.DBDate).Value = date;
        // Execute the command etc
    }
