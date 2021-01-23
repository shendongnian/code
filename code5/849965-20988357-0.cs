        private void btnSave_Click(object sender, EventArgs e)
        {
            //For Trusted connection
            string cnStr = "Data Source=[Your SQL Server Name];Initial Catalog=[Your Database Name];Integrated Security=True";
            var cn = new System.Data.SqlClient.SqlConnection(cnStr);
            var cmd = new System.Data.SqlClient.SqlCommand();
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO TblProtocolDetails(KeyWord,Command,Return)VALUES(@keyword,@comm,@retur)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("(@keyword", ""));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("(@comm", ""));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("(@retur", ""));
                if (cn.State == ConnectionState.Open)
                {
                    int i = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        //Uncomment if only for new rows
                        //if (!row.IsNewRow)
                        //{
                            string keyword = row.Cells[0].Value.ToString();
                            string name = row.Cells[1].Value.ToString();
                            string comm = row.Cells[2].Value.ToString();
                            string retur = row.Cells[3].Value.ToString();
                            string message = row.Cells[4].Value.ToString();
                            cmd.Parameters[0].Value = keyword;
                            cmd.Parameters[1].Value = comm;
                            cmd.Parameters[2].Value = retur;
                            if (cmd.ExecuteNonQuery() > 0)
                            {//Insert Successful!
                                //DO SOMETHING
                            }
                            else
                            {//Insert failed.
                                //DO SOMETHING
                            }
                            //i = pbl.fsave(keyword, name, comm, retur, message);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Dispose();
            if (cn.State != ConnectionState.Closed)
                cn.Close();
            cn.Dispose();
        }
