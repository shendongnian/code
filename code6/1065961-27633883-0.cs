     protected void saveSettings()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sendyourmessageConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            string userName = "something";
        
                try
                {
                    cmd = new SqlCommand("UPDATE Tb_Registration SET Country = @Country, City = @City Where Username = @Username" , con);
        
                    cmd.Parameters.AddWithValue("@Username", userName);
    
        
                    cmd.Parameters.AddWithValue("@Country",  txtCountry.Text.Trim());
    
        
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                   
        
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                    return;
                }
                finally
                {
                    con.Close();
                    cmd.Dispose();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Your settings have been saved');", true);
                }
        }
