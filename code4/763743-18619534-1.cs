    var connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filepath + "';Extended Properties=Excel 8.0;";
    var sqlx = string.Format("Update [Resolved Results$] set [Audit Result] = 'AUDITED' where [LineNo] IN ({0})", linesx);
    using (var connection = new OleDbConnection(connectionString))
    using (var command = new OleDbCommand(sqlx , connection))
    {
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            updRes = "Failed! :("+Environment.NewLine+"ERROR: " + ex.Message + Environment.NewLine;
        }
    }
