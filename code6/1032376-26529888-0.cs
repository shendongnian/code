    string UpdateCommand = "sptimeupdate";
    using(SqlConnection sqlConnectionCmdString = new SqlConnection(......))
    using(SqlCommand sqlRenameCommand = new SqlCommand(UpdateCommand, sqlConnectionCmdString))
    {
        DateTime td = Convert.ToDateTime(toolDate.Text);
        sqlRenameCommand.CommandType = CommandType.StoredProcedure;    
        sqlRenameCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = Clientid[up].ToString();
        sqlRenameCommand.Parameters.Add("@datetime", SqlDbType.DateTime).Value = td;
        sqlConnectionCmdString.Open();
        sqlRenameCommand.ExecuteNonQuery();
    }
