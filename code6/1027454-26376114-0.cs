    byte[] imgByteArrLogo = new byte[0];
                using (SqlConnection con = new SqlConnection("Your Connection string Here"))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlTransaction _pTrans = con.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells["Image_of_Employee"].Value != null)
                            {
                                Image _dgvImage = (Image)dataGridView1.Rows[i].Cells["Image_of_Employee"].Value;
                                MemoryStream ms = new MemoryStream();
                                _dgvImage.Save(ms, ImageFormat.Jpeg);
                                imgByteArrLogo = new byte[ms.Length];
                                ms.Position = 0;
                                ms.Read(imgByteArrLogo, 0, imgByteArrLogo.Length);
                            }
                            else
                            {
                                imgByteArrLogo = new byte[0];
                            }
    
                            try
                            {
                                string sql = "INSERT INTO dailydemo (S_No,Employee_Id ,Employee_Name ,In_time ,Out_Time ,Date,Week_No_of_The_Month,Attendance,Work_status,Remarks,Image_of_Employee) VALUES (@S_No,@Employee_Id ,@Employee_Name ,@In_time ,@Out_Time ,@Date,@Week_No_of_The_Month,@Attendance,@Work_status,@Remarks,@Image_of_Employee)";
                                using (SqlCommand cmd = new SqlCommand(sql, con, _pTrans))
                                {
                                    cmd.Parameters.Add(new SqlParameter("@S_No", dataGridView1.Rows[i].Cells["S_No"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Employee_Id", dataGridView1.Rows[i].Cells["Employee_Id"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Employee_Name", dataGridView1.Rows[i].Cells["Employee_Name"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@In_time", dataGridView1.Rows[i].Cells["In_time"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Out_Time", dataGridView1.Rows[i].Cells["Out_Time"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Week_No_of_The_Month", dataGridView1.Rows[i].Cells["Week_No_of_The_Month"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Attendance", dataGridView1.Rows[i].Cells["Attendance"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Work_status", dataGridView1.Rows[i].Cells["Work_status"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Remarks", dataGridView1.Rows[i].Cells["Remarks"].Value));
                                    cmd.Parameters.Add(new SqlParameter("@Image_of_Employee", imgByteArrLogo));
                                    cmd.ExecuteScalar();
                                }
                            }
                            catch (Exception exp)
                            {
                                _pTrans.Rollback();
                                con.Close();
                                _pTrans.Dispose();
                                MessageBox.Show(exp.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        _pTrans.Commit();
                        _pTrans.Dispose();
                        con.Close();
                    }
                }
