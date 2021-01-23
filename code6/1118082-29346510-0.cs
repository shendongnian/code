    string username=TextBox1.Text;
    string password=TextBox2.Text;
    string query = "SELECT COUNT(*) FROM Account WHERE acc_username=@username and 
    AND acc_password=@password";
    cmd.Parameters.AddWithValue("@username",username);
    cmd.Parameters.AddWithValue("@password",password);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
           if (dt.Rows.Count > 0)
            {
              Response.Redirect("page2.aspx");
            }
            else
            {
             Label1.Visible = true;
            }
