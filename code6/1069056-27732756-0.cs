    using (SqlConnection myConnection = new SqlConnection(connectionString))
    {
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(select, myConnection);
        myCommand.Parameters.AddWithValue("@ProjectId", querystring);
        object result = myCommand.ExecuteScalar();
        if (result != null && result.ToString().Equals(btn1.CommandArgument.ToString()))
        {
            Button hdn = (Button)e.Item.FindControl("addFollowerButton");
            btn1.Visible = false;
        }
    }
