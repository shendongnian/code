    protected void deleteBtn_Click1(object sender, EventArgs e)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteProc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            ListViewItem item = List1.Items[List1.SelectedIndex];
                            Label hdn = (Label)item.FindControl("hiding");
                            string tmp = hdn.Text;
                            int sId = Int32.Parse(tmp);
                            cmd.Parameters.AddWithValue("someId", sId);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.ToString());
                        }
                    }
                }
            }
