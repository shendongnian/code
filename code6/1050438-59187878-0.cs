                cmd = new SqlCommand("Select YearName from Year where YearName='" + txtYear.Text + "'", ConnOpen());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Duplicate Values are not valid!!!");
                }
                else
                {
                    if (Classes.ClassDatabaseConnection.UserMessage("Are you srue you want to Add this Year!!!", "Confirm Updation") == true)
                    {
                        string insert = "insert into Year(YearName) values('" + txtYear.Text + "')";
                        int result = sqlrep.ExecuteNonQuery(insert);
                        if (result > 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Year Added Successfully.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                    }
                    dataLoad();
                }
            }
