    protected void btn_login_Click(object sender, EventArgs e)
    {
        using(SqlConnection conn = new SqlConnection(...))
        {
            conn.Open();
            string cmdText = @"Select Title 
                               from [tblEmployee] 
                               where UserID= @id AND Password = @pwd";
            SqlCommand com = new SqlCommand(cmdText, conn);
            com.Parameters.AddWithValue("@id", txt_userID.Text)
            com.Parameters.AddWithValue("@pwd", txt_password.Text);
            using(SqlDataReader reader = com.ExecuteReader())
            {
                if(reader.Read())
                {
                    string title = reader["Title"].ToString();
                    switch(title)
                    {
                        case "Administrator":
                           Session["New"] = txt_userID.Text;
                           Response.Write("Password is correct.");
                           Response.Redirect("~/Administrator Home Page.aspx");
                           break;
                        case "Director":
                           Session["New"] = txt_userID.Text;
                           Response.Write("Password is correct.");
                           Response.Redirect("~/Director Home Page.aspx");
                           break;
                        case "Member":
                           Session["New"] = txt_userID.Text;
                           Response.Write("Password is correct.");
                           Response.Redirect("~/Member Home Page.aspx");
                           break;
                        default:
                           Response.Write("Unknown title: " + title);
                           break;
                    }
               }
               else
                  Response.Write("Login is incorrect.");
           }
       }
    }
