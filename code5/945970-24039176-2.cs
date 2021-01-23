    private void UsersListDD()
    {
        userddlist.Items.Clear();
        userddlistedit.Items.Clear();
        userddlistdelete.Items.Clear();
        string selectSQL = "SELECT * FROM personnel";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem newItem = new ListItem();
                newItem.Text = reader["FirstName"] + " " + reader["LastName"];
                newItem.Value = reader["HR_ID"].ToString();
                userddlist.Items.Add(newItem);
                userddlistedit.Items.Add(newItem);
                userddlistdelete.Items.Add(newItem);
            }
            reader.Close();
        }
        finally
        {
            con.Close();
        }
    }
