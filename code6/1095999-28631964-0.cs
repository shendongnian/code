    private void button1_Click(object sender, EventArgs e)
            {
                string username = "Admin";
                string password = "root";
                //When both are empty
                if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Fields are not filled");
                    return;
                }
                //When username is empty    
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("No username inserted");
                    return;
                }
                //When password is empty
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("No password inserted");
                    return;
                }
    
                if ((textBox1.Text == username) && (textBox2.Text == password))
                    MessageBox.Show("Login Succeed");
                else
                    MessageBox.Show("Login failed");
    
            }
