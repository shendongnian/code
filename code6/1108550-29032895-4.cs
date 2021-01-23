    try
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssignmentDBConnectionString"].ConnectionString);
        conn.Open();
        string insertQuery = "insert into [AsTable] ([Username],Email,Password) values (@Username ,@Email, @Password)";
        SqlCommand com = new SqlCommand(insertQuery, conn);
        com.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
        com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
        com.Parameters.AddWithValue("@password", ToSHA256(TextBoxPass.Text));
        com.ExecuteNonQuery();
        Response.Redirect("Manager.aspx");
        Response.Write("Registration Completed");
        conn.Close();
    }
    catch (Exception ex)
    {
        Response.Write("Error:"+ex.ToString());
    }
