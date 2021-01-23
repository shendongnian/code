             SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader != null)
                {
                    Response.Redirect("UserCenter.aspx");
                }
            }
                else
                {
                    correct.Text = "Incorrect Credentials".ToString(); 
                    correct.Visible = true;
                }
            
            reader.Close();
            con.Close();
