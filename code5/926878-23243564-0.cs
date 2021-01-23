            DateTime? dtStart = null, dtFrom = null;
            try
            {
                dtStart = DateTime.Parse(AccountingStart.Text.Trim());
            }
            catch { }
            if (!dtStart.HasValue)
            { 
                // error check here.
            }
            try
            {
                dtFrom = DateTime.Parse(AccountingFrom.Text.Trim());
            }
            catch { }
            if (!dtFrom.HasValue)
            { 
                // error check here.
            }
            using (SqlConnection sqlConn = new SqlConnection("Data Source=.\\SqlExpress; Integrated Security=True; AttachDbFilename=|DataDirectory|\\Garment.mdf; User Instance=true;"))
            {
                sqlConn.Open();
                SqlTransaction sqlTransaction = null;
                string cb = "INSERT INTO COMPANY_MASTER(C_Name,M_Name,L_No,Tax_No,PO_No,Location,State,Country,Telephone,Fax_No,Email_Id,Website,Currency_Name,Company_logo,APT,APF) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)";
                try
                {
                    SqlCommand cmd = sqlConn.CreateCommand();
                    cmd.CommandText = cb;
                    sqlTransaction = sqlConn.BeginTransaction();
                    cmd.Transaction = sqlTransaction;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@1", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "C_Name", DataRowVersion.Current, textBox2.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@2", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "M_Name", DataRowVersion.Current, textBox3.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@3", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "L_No", DataRowVersion.Current, textBox4.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@4", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Tax_No", DataRowVersion.Current, textBox5.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@5", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "PO_No", DataRowVersion.Current, textBox6.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@6", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Location", DataRowVersion.Current, textBox7.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@7", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "State", DataRowVersion.Current, textBox8.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@8", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Country", DataRowVersion.Current, textBox9.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@9", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Telephone", DataRowVersion.Current, textBox10.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@10", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Fax_No", DataRowVersion.Current, textBox11.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@11", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "email_Id", DataRowVersion.Current, textBox12.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@12", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Website", DataRowVersion.Current, textBox13.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@13", SqlDbType.NChar, 10, ParameterDirection.Input, false, 0, 0, "Currency_Name", DataRowVersion.Current, textBox14.Text.Trim()));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (Bitmap bmpImage = new Bitmap(pictureBox1.Image))
                        {
                            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] data = ms.GetBuffer();
                            cmd.Parameters.Add(new SqlParameter("@14", SqlDbType.Image, 10, ParameterDirection.Input, false, 0, 0, "Currency_Name", DataRowVersion.Current, data));
                        }
                    }
                    cmd.Parameters.Add(new SqlParameter("@15", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "APT", DataRowVersion.Current, dtStart));
                    cmd.Parameters.Add(new SqlParameter("@16", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "APF", DataRowVersion.Current, dtFrom));
                    cmd.ExecuteScalar();
                    sqlTransaction.Commit();
                    MessageBox.Show("Successfully saved ", "Company", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch { }
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
