    private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Junz\Documents\Register - Copy.mdb";
            conn.Open();
            String Username = textBox1.Text;
            String Password = textBox2.Text;
            String Email = textBox3.Text;
            String Address = textBox4.Text;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Register(Username,Password,Email,Address) Values(@Username, @Password,@Email,@Address)";
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Username", OleDbType.VarChar,20).Value = Username;
                cmd.Parameters.Add("@Password", OleDbType.VarChar,20).Value = Password;
                cmd.Parameters.Add("@Email", OleDbType.VarChar,20).Value = Email;
                cmd.Parameters.Add("@Address", OleDbType.VarChar,20).Value = Address;
                try
                {
                    cmd.ExecuteNonQuery();
                     MessageBox.Show("DATA ADDED");
                       conn.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }
