    using (var con = new SqlConnection("Data Source=ali-pc/sqlexpress.PakEstateAgency.dbo"))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("insert into ClientINFO(Application#,LDAReg#,Size,Name,SDW/O,CNIC,Address,Image,giventime)" + "values (@Application#,@LDAReg#, ... )", con))
                    {
                        cmd.Parameters.AddWithValue("@Application#", Convert.ToInt32(textBox1.Text));
                        cmd.Parameters.AddWithValue("@LDAReg#", textBox2.Text);
                        // add the other parameters ...
    
                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Insertion successfully done");
