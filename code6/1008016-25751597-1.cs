    OleDbConnection connection = LABMeetingRecordsDB.GetConnection();
    string insertStatement = "INSERT INTO DocumentInfo " + "([FileName], [Date], [Subject], [Type]) " + "VALUES (?, ?, ?, ?)";
    OleDbCommand insertCommand = new OleDbCommand(insertStatement, connection);
    insertCommand.Parameters.AddWithValue("@FileName", record.FileName);
    insertCommand.Parameters.AddWithValue("@Date", (DateTime)record.Date ?? (object)DBNull.Value);
    insertCommand.Parameters.AddWithValue("@Subject", record.Subject);
    insertCommand.Parameters.AddWithValue("@Type", record.getDBType ?? (object)DBNull.Value);
    connection.Open();
    try
    {
      insertCommand.ExecuteNonQuery();
    }
    catch(OleDbException e)
    {
       LogYourMessage(e.Message);
    }
