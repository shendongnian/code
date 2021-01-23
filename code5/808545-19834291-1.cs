    SqlCommand cmd = new SqlCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommadnText = "upgrade LoginForm set Password ='" + txtConPassword.Text + "' where UserName ='" + txtUser.Text + "'";
    cmd.Connection = conn;
    conn.Open();
                    var test = cmd.ExecuteNonQuery();
                    if (test == 1)
                    {
                        MessageBox.Show("Password has been reset");
                    }
                    else
                    {
                        MessageBox.Show("Password did not reset");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed....." + ex.Message);
    
                }
                finally
                {
                   if (conn.State == ConnectionState.Open)
                   {
                       conn.Close();
                   }
                }
