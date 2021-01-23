    if (e.CommandName == "Edit")
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "Select * FROM Table1 WHERE Id = @Id";
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = e.CommandArgument.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        TextBox_Text.Text=reader["Text"].ToString();;
           
        conn.Close();
        Repeater1.DataBind();
    }
   
