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
        if (reader.Read())
        {
            TextBox txt=new TextBox();
            txt.ID= "mytextID";
            txt.Text=reader["Text"].ToString();;
            e.Controls.Add(txt); // Or If you have runat=server on table, you can use table id and append the control to first td tag
            // Or you add a placeholder or Panel and show it on edit and append the control it to.
        }
        conn.Close();
        Repeater1.DataBind();
    }
   
