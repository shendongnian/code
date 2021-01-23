      private void Radiobutton1_Checked(object sender, EventArgs e)
        {  
          try
             {    
               SqlConnection con = new SqlConnection(Connectionstring);
               con.Open(); 
               using (con)
                 {          
                    String sql = "update leavetable set status =@status where eid =@ID  and status = 'NULL'");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("status updated");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                  }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }      
        }
