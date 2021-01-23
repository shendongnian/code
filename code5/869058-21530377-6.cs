                boolean IsIDExist()
                {
                    SqlCommand cmd = new SqlCommand();                   
                    string sql = @"SELECT count(*) from  patient                           
                            WHERE pIC = @pIC" and pUserName!='' and pPassword !=''";
                    cmd.Parameters.AddWithValue("@pIC", txtIC.Value);
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    con.Open();
                    if(Convert.ToInte32(cmd.ExecuteScalar())>0)
                    return true;
                     
                    return false;
                }
       if (Page.IsValid)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sacpConnectionString"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    Guid guid;
                    guid = Guid.NewGuid();
                    string sql = @"UPDATE patient 
                            SET 
                            pUserName = @pUserName,
                            pPassword = @pPassword
                            WHERE pIC = @pIC and pUserName='' and pPassword=''";
                    cmd.Parameters.AddWithValue("@pIC", txtIC.Value);
                    cmd.Parameters.AddWithValue("@pUsername", txtUsername.Value);
                    cmd.Parameters.AddWithValue("@pPassword", txtPassword.Value);
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    
                   
                    if (!IsIDExist())
                    {
                        Session.Add("ID", id);
                        Session.Add("Username", txtUsername.Value);
                        Session.Add("Password", txtPassword.Value);
                        FormsAuthentication.SetAuthCookie(txtUsername.Value, true);
                        Response.Redirect("registered.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "IC Already Exist";
                    }
                }
                /*
                catch (Exception)
                {
                    lblErrorMessage.Text = "IC does not exist";
                }
                */
                finally
                {
                    con.Close();
                }
            }
        }
