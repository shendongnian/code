     public static void FillDropDownList(System.Windows.Forms.ComboBox cboMethodName, String myDSN, String myServer)
            {
                SqlDataReader myReader;
                String ConnectionString = "Server="+myServer+"\\sql2008r2;Database="+myDSN+";Trusted_Connection=True;";
    
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select * from tablename", cn);
                        using (myReader = cmd.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                cboMethodName.Items.Add(myReader.GetValue(0).ToString());
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(e.ToString());
                        return;
                    }
                }
            }
