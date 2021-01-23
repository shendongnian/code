     public void binddata()
            {
                
                try
                {
                    customerDataSetBindingSource.DataSource = cmdselect;
                    dataGridView1.DataSource = customerDataSetBindingSource;
    
                    SqlConnection con = new SqlConnection(constring);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand(cmdselect, con);
    
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
               
    
                    MessageBox.Show("Data Updated");
                    con.Close();
                
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
    
          
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection(constring);
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(cmdInsert, con);
               
                
    
                try
                {
                    if (isvalid(textEmail.Text))
                    {
                        da.InsertCommand.Parameters.Add("@firstName", SqlDbType.VarChar);
                        da.InsertCommand.Parameters["@firstName"].Value = textFirstName.Text.Trim();
                        da.InsertCommand.Parameters.Add("@surname", SqlDbType.VarChar);
                        da.InsertCommand.Parameters["@surname"].Value = textSurname.Text.Trim();
                        da.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar);
                        da.InsertCommand.Parameters["@email"].Value = textEmail.Text.Trim();
                        da.InsertCommand.Parameters.Add("@phone", SqlDbType.VarChar);
                        da.InsertCommand.Parameters["@phone"].Value = textPhone.Text.Trim();
                        da.InsertCommand.Parameters.Add("@mobile", SqlDbType.VarChar);
                        da.InsertCommand.Parameters["@mobile"].Value = textMobile.Text.Trim();
    
                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Customer Added");
                        con.Close();
                        clearboxes();
                        binddata();
                        
                    }
                    else
                    {
                        textEmail.BackColor = Color.Red;
                    }
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
    
                }
            }
