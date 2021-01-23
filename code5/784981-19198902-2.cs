    protected void Button1_Click(object sender, EventArgs e)
    {
        // Command with parameters that check if a user with the supplied credentials exists
        // If the user exists then just one record is returned from the datatable....
        string cmdText = "SELECT FirstName,LastName " + 
                         "FROM Employees " + 
                         "WHERE username=@uname and pass=@pwd";
        using(SqlConnection cnn = new SqlConnection(.....))
        using(SqlCommand cmd = new SqlCommand(cmdText, cnn))
        {
             cnn.Open();
             cmd.Parameters.AddWithValue("@uname", TextBox1.Text);
             cmd.Parameters.AddWithValue("@pwd", TextBox2.Text);
             using(SqlDataReader reader = cmd.ExecuteReader())
             {
                  // If the Read returns true then a user with the supplied credentials exists 
                  // Only one record is returned, not the whole table and you don't need to 
                  // compare every record against the text in the input boxes 
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
    
