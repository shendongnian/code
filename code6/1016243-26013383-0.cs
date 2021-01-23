    if (textBox1.Text != "" || textBox2.Text != "")
            {
                bool flag=false;
                for (int i = 0; i < passwords.Length; i++)
                {
                    if (textBox1.Text == usernames[i] && textBox2.Text == passwords[i])
                    {
                        this.Hide();
                        new Form2().Show();
                        flag=true;
                    }
    
                  }
                   if(flag==false)
                    {
                       MessageBox.Show("wrong");
                    }
            }
            else
            {
                MessageBox.Show("please fill user & password");
            }
