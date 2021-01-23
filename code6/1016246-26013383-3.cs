    if (textBox1.Text != "" || textBox2.Text != "")
            {
                bool flag=false;
                for (int i = 0; i < passwords.Length; i++)
                {
                    if (textBox1.Text == usernames[i] && textBox2.Text == passwords[i])
                    {
                       
                       
                        flag=true;
                     
                    }
    
                  }
                   if(flag==true)
                    {
                      flag=false;
                      this.Hide();
                        new Form2().Show();                      
                    }
                else
                 {
                     MessageBox.Show("wrong");
                }
            }
            else
            {
                       
                MessageBox.Show("please fill user & password");
            }
