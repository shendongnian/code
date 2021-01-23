      protected void Button1_Click(object sender, EventArgs e)
    {
        string conn = "";
        conn = ConfigurationManager.ConnectionStrings["employee1ConnectionString"].ToString();
        SqlConnection objsqlconn = new SqlConnection(conn);
        objsqlconn.Open();
        SqlCommand cmd = new SqlCommand("select * from userdata where username=@username and password=@password", objsqlconn);
        cmd.Parameters.AddWithValue("@username", TextBox1.Text);
        cmd.Parameters.AddWithValue("@password", TextBox1.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["permission"].ToString() == "admin")
            {
                Response.Redirect("Add.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Label1.Text = "Invalid username or password. Please try again.";
        }
    }
