    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string ccc = CCC.Properties.Settings.Default.CCCConnectionString;
            string x = string.Empty;
                x = "Insert Into Test$ (unitval,balance,avg)"
                    + " Values(@uval,@balance,@avg)";
                using (SqlConnection c = new SqlConnection(ccc))
                {
                    using (SqlCommand cmd = new SqlCommand(x, c))
                    {
                        c.Open();
                        DataSet ds = new DataSet();
                        string sql = "select * From Test$";
                        SqlDataAdapter da = new SqlDataAdapter(sql, c);
                        da.Fill(ds, "Test$");
                        //DataTable dt = ds.Tables[0];
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(r[7]) != 0)
                            {
                                r[8] = Convert.ToInt32(r[8]) + Convert.ToInt32(r[6]);
                                cmd.Parameters.AddWithValue("@balance", r[8]);
                                r[9] = ((Convert.ToInt32(r[6]) - Convert.ToInt32(r[8]) * Convert.ToDouble(r[9])) + (Convert.ToDouble(r[7]) * Convert.ToInt32(r[6]))) / Convert.ToInt32(r[8]) + Convert.ToInt32(r[6]);
                                cmd.Parameters.AddWithValue("@avg", r[9]);
                            }
                            else
                            {
                                r[7] = r[9];
                                cmd.Parameters.AddWithValue("@uval", r[9]);
                                r[8] = Convert.ToInt32(r[8]) - Convert.ToInt32(r[6]);
                                cmd.Parameters.AddWithValue("@balance", r[8]);
                                r[9] = r[9];
                                cmd.Parameters.AddWithValue("@avg", r[9]);
                            }
                            cmd.ExecuteNonQuery();
                            c.Close();
                            label2.Text = "Done";
                        }
                    }
                }
            }
            catch (Exception f)
            {
                label2.Text = "Not Inserted" + "Error: " + f.Message;
            }
