    using(SqlConnection myConnection = new SqlConnection(global::AliBabaMailer.Properties.Settings.Default.DatabaseConnectionString))
    using(SqlCommand myCommand = new SqlCommand("INSERT INTO Companies (Name) " + "Values ('string')", myConnection))
    {
        myConnection.Open();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }
