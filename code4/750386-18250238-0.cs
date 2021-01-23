    string tmpTableDefinition = "create table #tmpEmails (...)";
    using(var connection = new SqlCeConnection(connectionString))
    {
        //Create temp table
        var tmpTableCommand = new SqlCeCommand(tmpTableDefiniton, connection);
        tmpTableCommand.ExecuteNonQuery();
        //Bulk copy to the temp table, note that bulk copy run faster if the teble is empty
        //which is always true in this case...
        using (var bc = new SqlCeBulkCopy(connection, options))
        {
             bc.DestinationTableName = "#tmpEmails";
             bc.WriteToServer(dt);
        }
        //Run a sp, that have temp table and original one, and marge as you wish in sql
        //for sp to compile properly, you would have to copy tmp table to script too
        var spCommand = new SqlCommand("sp_MargeTempEmailsWithOriginal", connection);
        spCommand.Type = SP //Don't remember exact prop name and enum value
        spCommand.ExecuteNonQuery();
    }
