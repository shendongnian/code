    public void GetInformation()
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM tblUsers WHERE voter_name = '" + Request.QueryString["VotersID"].ToString() + "'";
        OleDbDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            lblVoterName.Text = reader["usr_FirstN"].ToString() + " " + reader["usr_LastN"].ToString();
        }
    }
