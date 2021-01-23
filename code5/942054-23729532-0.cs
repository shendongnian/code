    private void button1_Click(object sender, EventArgs e)
    {
        bool validInput = false;
     
        if (!String.IsNullOrWhitespace(textBox1.Text))
        {
            validInput = true;
        }
        else
        {
            MessageBox.Show("Please enter a user name.");
        }
        if (!String.IsNullOrWhitespace(textBox2.Text))
        {
            validInput = true;
        }
        else
        {
            MessageBox.Show("Please enter a password.");
        }
        if (validInput)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=MJ-PC\\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM tblUsers WHERE U_Name = @U_Name AND U_Pass = @U_Pass", conn);
                command.Parameters.Add("@U_Name", SqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@U_Pass", SqlDbType.VarChar).Value = textBox2.Text;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string userType = reader["U_type"].ToString();
                        if (userType == "1")
                        {
                            // Handle regular users
                        }
                        else if (userType == "2")
                        {
                            // Handle admin users
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login failed.");
                    }
                }
            }
        }
    }
