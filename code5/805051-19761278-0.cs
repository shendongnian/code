          private void button1_Click(object sender, EventArgs e)
        {
            if (label60.Text == "new")
            {
                try
                {
                    System.Data.OleDb.OleDbConnection MyConnection;
                    System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                    MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Declan\\Documents\\Declan\\output.xlsx;Extended Properties=\"Excel 8.0;HDR=Yes;\" ");
                    MyConnection.Open();
                    myCommand.Connection = MyConnection;
                    DateTime date1 = dateTimePicker1.Value;
                    string date2 = date1.ToString("dd/MM/yyyy");
                    myCommand.CommandText = "Insert into [Database$] ([date],postcode,type,source,income,profession,phonenumber) values(@date, @post, @type,@source,@income,@prof,@jobnum)";
                    myCommand.Parameters.AddWithValue("@date",date2);
                    myCommand.Parameters.AddWithValue("@post", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@type", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@source", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@income", textBox6.Text);
                    myCommand.Parameters.AddWithValue("@prof", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@jobnum", textBox8.Text);
                    myCommand.ExecuteNonQuery();
                    MyConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
             label60.Text = "edit";
            }
        }
