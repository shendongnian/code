       if(RadioButton1.Checked)
    
            {
    
                if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
    
    
                    Response.Redirect("Default.aspx");
                else
                    //Response.Write("error");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Currect Passward');", true);
                  
            }
    
    
    
                else if (RadioButton2.Checked)
                {
    
    
                    string query = "SP_StudLogin";
                    SqlCommand com = new SqlCommand(query,con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@username", txtUsername.Text.ToString());  //for username 
                    com.Parameters.AddWithValue("@password", txtPassword.Text.ToString()); //for password
                    con.Open();
                    //int usercount = (int)com.ExecuteScalar();// for taking single value
    
                    int usercount = (Int32)com.ExecuteScalar();
                    con.Close();
    
    
    
                    if (usercount == 1)  // comparing users from table 
                    {
                        Response.Redirect("DeafultStaff.aspx");  //for sucsseful login
                    }
                    else
                    {
    
                        //lblmsg.Text = "Invalid User Name or Password";  //for invalid login
    
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Currect Passward');", true);
                    }
    
                }
