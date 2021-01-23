    public void DisplayData()
        {
            string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\listm\Documents\Visual Studio 2013\Projects\EnviroWaste Job Logger\EnviroWaste Job Logger\UsersDatabase.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM LoggedJobs WHERE (UserID = @userID)", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            try
                            {
                                sda.Fill(dt);
                                //Set AutoGenerateColumns False
                                tblLoggedJobs.AutoGenerateColumns = true;
                                //Set Columns Count
                                tblLoggedJobs.ColumnCount = 7;
                                //Add Columns
                                tblLoggedJobs.Columns[0].Name = "JobID";
                                tblLoggedJobs.Columns[0].HeaderText = "Job ID";
                                tblLoggedJobs.Columns[0].DataPropertyName = "JobID";
                                tblLoggedJobs.Columns[1].Name = "JobDate";
                                tblLoggedJobs.Columns[1].HeaderText = "JobDate";
                                tblLoggedJobs.Columns[1].DataPropertyName = "JobDate";
                                tblLoggedJobs.Columns[2].Name = "UserID";
                                tblLoggedJobs.Columns[2].HeaderText = "User ID";
                                tblLoggedJobs.Columns[2].DataPropertyName = "UserID";
                                tblLoggedJobs.Columns[3].Name = "IssueSubject";
                                tblLoggedJobs.Columns[3].HeaderText = "IssueSubject";
                                tblLoggedJobs.Columns[3].DataPropertyName = "IssueSubject";
                                tblLoggedJobs.Columns[4].Name = "Screen";
                                tblLoggedJobs.Columns[4].HeaderText = "Screen";
                                tblLoggedJobs.Columns[4].DataPropertyName = "Screen";
                                tblLoggedJobs.Columns[5].Name = "FurtherInformation";
                                tblLoggedJobs.Columns[5].HeaderText = "FurtherInformation";
                                tblLoggedJobs.Columns[5].DataPropertyName = "FurtherInformation";
                                tblLoggedJobs.Columns[6].Name = "JobStatus";
                                tblLoggedJobs.Columns[6].HeaderText = "JobStatus";
                                tblLoggedJobs.Columns[6].DataPropertyName = "JobStatus";
                                tblLoggedJobs.DataSource = dt;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.StackTrace);
                                MessageBox.Show("Not working");
                            }
                            
                        }
                    }
                }
            }
        }
