      private void btnLogin_Click(object sender, EventArgs e)
            {
                //retrieve connection information info from App.config
                string strConnectionString = ConfigurationManager.ConnectionStrings["sacpConnection"].ConnectionString;
                //STEP 1: Create connection
                SqlConnection myConnect = new SqlConnection(strConnectionString);
                //STEP 2: Create command
                string strCommandtext = "SELECT dUsername, dPassword from DOCTOR";
                // Add a WHERE Clause to SQL statement
                strCommandtext += "   WHERE dUsername=@dname AND dPassword=@dpwd;";
                strCommandtext += "SELECT nUsername, nPassword from NURSE WHERE nUsername=@nname AND nPassword=@npwd;";
                SqlCommand cmd = new SqlCommand(strCommandtext, myConnect);
                cmd.Parameters.AddWithValue("@dname", textUsername.Text);
                cmd.Parameters.AddWithValue("@dpwd", txtPassword.Text);
                cmd.Parameters.AddWithValue("@nname", textUsername.Text);
                cmd.Parameters.AddWithValue("@npwd", txtPassword.Text);
                try
                {
                    // STEP 3: open connection and retrieve data by calling ExecuteReader
                    myConnect.Open();
                    // STEP 4: Access Data
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) //For Doctor
                    {
                        if (MessageBox.Show("Login Successful") == DialogResult.OK)
                        {
                            JobPosition = 1; //Doctor
                            page_two form = new page_two(JobPosition);
                            form.Show();
                            return;
                        }                                     
                    } 
                    reader.NextResult();
                    while (reader.Read()) //For Nurse
                    {
                        if (MessageBox.Show("Login Successful") == DialogResult.OK)
                        {
                            
                            JobPosition = 2; //Nurse
                            page_two form = new page_two(JobPosition);
                            form.Show();
                            return;
                        }
                    }
                    //STEP 5: close connection
                    reader.Close();
                    MessageBox.Show("Invalid username or password");
                }
                catch (SqlException ex)
                {
                }
                finally
                {
                    //STEP 5: close connection
                    myConnect.Close();
                }
            }    
