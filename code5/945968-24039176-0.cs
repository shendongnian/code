    protected void userddlistedit_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectSQL;
        selectSQL = "SELECT * FROM users ";
        selectSQL += "WHERE HR_ID='" + userddlistedit.SelectedItem.Value + "'";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            usernameedit.Text = reader["Username"].ToString();
            passwordedit.Text = reader["Password"].ToString();
            accessleveledit.SelectedValue = reader["AccessLevel"].ToString();
            reader.Close();
            lblResults.Text = "";
        }
        finally
        {
            con.Close();
        }
    }
