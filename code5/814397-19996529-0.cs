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
                }
