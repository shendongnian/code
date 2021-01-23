        private void UpdateDetails_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection();
                con.ConnectionString = Helper.MyConnectionString;
                con.Open();
                for (int i = 0; i <= datagridview1.Rows.Count - 1; i++)
                {
                    int j = i + 1; // j is the serial number corresponding to partnumber
                    string partno = dgv1.Rows[i].Cells[2].Value.ToString(); //getting part number from Datagridview
                    //String partquery = "";
                    //if (partno == null || partno == "") //checking whether part number updated or not
                    //{
                    //    partquery = "update Vendor SET PartNo=NULL where Vendor.Sno=" + j + " ";
                    //}
                    //else
                    //    partquery = "update Vendor SET PartNo='" + partno + "' where Vendor.Sno=" + j + " ";
                    OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("update Vendor SET PartNo='@partno' where Vendor.Sno=@vndid");
                    OleDbParameter parameter = new System.Data.OleDb.OleDbParameter("@partno", partno);
                    cmd.Parameters.Add(parameter);
                    parameter = new System.Data.OleDb.OleDbParameter("@vndid", j);
                    cmd.Parameters.Add(parameter);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //exception handler
            }
        }
