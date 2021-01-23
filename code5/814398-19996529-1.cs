        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
                {
                    
                    if (e.KeyCode == Keys.Enter)
                    {
                        // call function here to Insert TextBox1 data into database
                        InsertMyData(TextBox1.Text.ToString());    
                    }
                }
                private void InsertMyData(String value1)
                {
                  //Insert Data into database
                  String strCon = "Data Source=(local);Initial Catalog=mydatabase;uid=uid;pwd=pwd;Integrated Security=True;";
                 using (SqlConnection sqlCon = new SqlConnection(strCon))
                 {
                    String strCmd = "insert into mytable(value1) value(@myvalue1)";
                        using (SqlCommand sqlcommand = new SqlCommand(strCmd, sqlCon))
                        {
                        sqlCon.Open();
                        sqlcommand.Parameters.AddWithValue("@myvalue1", value1);
                        sqlcommand.ExecuteNonQuery()
                        }
                  }                 
                }
