    if (textBox1.Text != "" || textBox2.Text != "")
            {
                bool flag=false;
                for (int i = 0; i < passwords.Length; i++)
                {
                    if (textBox1.Text == usernames[i] && textBox2.Text == passwords[i])
                    {
                        textBox1.Text=string.Empty;
                        textBox2.Text=string.Empty;
                        this.Hide();
                        new Form2().Show();
                        flag=true;
                       Break ;
                    }
    
                  }
                   if(flag==false)
                    {
                        textBox1.Text=string.Empty;
                        textBox2.Text=string.Empty;
                       MessageBox.Show("wrong");
                    }
            }
            else
            {
                        textBox1.Text=string.Empty;
                        textBox2.Text=string.Empty;
                MessageBox.Show("please fill user & password");
            }
