    private  void RunMyCommand(String SQLCommand)
            {
                using (OleDbConnection con = new OleDbConnection())
                {
                    con.ConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Jim\Desktop\WindowsFormsApplication1\WindowsFormsApplication1\labels1.mdb;Persist Security Info=False";
                    con.Open();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = SQLCommand;
                        cmd.Parameters.AddWithValue("@SaleOrderNumber", label1.Text);
                        cmd.Parameters.AddWithValue("@NsN", label6.Text);
                        cmd.Parameters.AddWithValue("@NsNBarcode", label6.Text);
                        cmd.Parameters.AddWithValue("@PartNumber", label2.Text);
                        cmd.Parameters.AddWithValue("@Qty", label7.Text);
                        cmd.Parameters.AddWithValue("@Description", label3.Text);
                        cmd.Parameters.AddWithValue("@CustomerPo", label8.Text);
                        cmd.Parameters.AddWithValue("@CustomerPoBarcode", label8.Text);
                        cmd.Parameters.AddWithValue("@PackingCode", label4.Text);
                        cmd.Parameters.AddWithValue("@Weight", label9.Text);
                        cmd.Parameters.AddWithValue("@Clin", label5.Text);
                        cmd.Parameters.AddWithValue("@SaleOrderDate", label12.Text);
                        cmd.Parameters.AddWithValue("@MCM", label10.Text);
                        cmd.Parameters.AddWithValue("@Cage", label11.Text);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
    
                }
    
            }
