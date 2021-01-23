          string connectionstring = WebConfigurationManager.ConnectionStrings["userinfo.ConnectionString"].ConnectionString;
                    string sqlstring;
                    sqlstring = "Select UserName,Password from user  where UserName='" + 
    Texboxusername.Text + "' and Password ='" + Textboxpassword.Text + "'";
                  
                    SqlConnection con = new SqlConnection(connectionstring);
                    SqlCommand command = new SqlCommand(sqlstring, con);
                 
                    System.Data.SqlClient.SqlDataReader reader;
            
                    // open a connection with sqldatabase
                    con.Open();
                
                    reader = command.ExecuteReader();
              
                    if (reader.Read())//Reader.read() true if found in database
                    {
            
            Response.Redirect("userHome.aspx");
            }
            con.close();
