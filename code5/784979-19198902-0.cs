    protected void Button1_Click(object sender, EventArgs e)
    {
        string cmdText = "SELECT FirstName,LastName " + 
                         "FROM Employees " + 
                         "WHERE username=@uname and pass=@pwd";
        using(SqlConnection cnn = new SqlConnection(.....))
        using(SqlCommand cmd = new SqlCommand(cmdText, cnn))
        {
             cnn.Open();
             cmd.Parameters.AddWithValue("@uname", TextBox1.Text);
             cmd.Parameters.AddWithValue("@pass", TextBox2.Text);
             using(SqlDataReader reader = cmd.ExecuteReader())
             {
                  if(reader.Read())
                  {
                       Session["x"] = reader.GetString(0);
                       Response.Redirect("MemberPage.aspx");
                  }
                  else
                  {
                       Label2.Text = "Invalid credentials";
                  }
             }
         }
     }
    
