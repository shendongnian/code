    // Create the connection object once
    using (SqlConnection sqlConnectionCmdString = new SqlConnection(@"Data=.\SQLEXPRESS;AttachDbFilename=C:\Users\Shawn\Documents\Visual Studio 2010\Projects\Server\database\ClientRegit.mdf;Integrated Security=True;User Instance=True"))
    {
      // Same with the SqlCommand object and adding the parameters once also
      SqlCommand sqlRenameCommand = new SqlCommand("sptimeupdate", sqlConnectionCmdString);
      sqlRenameCommand.CommandType = CommandType.StoredProcedure;
      sqlRenameCommand.Parameters.Add("@id", SqlDbType.NVarChar);
      sqlRenameCommand.Parameters.Add("@datetime", SqlDbType.DateTime);
      // Open the connection once only
      sqlConnectionCmdString.Open();
      foreach (string clientid in searchClientID)
      {
        for (int up = 0; up < IntializedPorts.Count; up++)
        {
          try
          {
            // The below three lines seem redundant.
            // Clientid[up] will be equal to clientid after it all, so just use clientid
            //string[] Clientid;
            //Clientid = new string[IntializedPorts.Count];
            //Clientid[up] = clientid.ToString();
            sqlRenameCommand.Parameters["@id"].Value = clientid;
            sqlRenameCommand.Parameters["@datetime"].Value = toolDate.Text;
            sqlRenameCommand.ExecuteNonQuery();
          }
          // Might want to move this try..catch outside the two loops,
          // otherwise you will get this message each time an error happens
          // which might be alot, depending on the side of searchClientID
          catch (SqlException)
          {
            MessageBox.Show("Failed to UpdateCurrentTime", "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }
