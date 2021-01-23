        private void Button_AddCustomer_Click(object sender, EventArgs e)
        {
             try
             {
                 //SqlConnection objsqlconn = new SqlConnection(conn);
                 SqlConnection myConnection = new SqlConnection(
                 "Data Source=SHIRWANIPC;" + "Initial Catalog=TEST DATABASE;"
                                                + "Integrated Security=True");
                 myConnection.Open();
                 SqlCommand objcmd = new SqlCommand("INSERT INTO 
                       Customer(PhoneNumber,MobileNumber,Address) VALUES   
                      (@phonenumber,@mobilenumber,@address)", myConnection);
                objcmd.Parameters.AddWithValue("@phonenumber",TextBox1.Text);
                objcmd.Parameters.AddWithValue("@mobilenumber",TextBox2.Text);
                objcmd.Parameters.AddWithValue("@address",TextBox3.Text);
                objcmd.ExecuteNonQuery();
             }
             catch(SqlException ex)
             {
                  MessageBox.Show(ex.ToString());
             }
         }
