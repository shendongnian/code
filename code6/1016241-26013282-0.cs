    if (textBox1.Text == usernames[i])
                {
                    if(textBox2.Text == passwords[i]) 
                    {
                       this.Hide();
                       new Form2().Show();
                    }                
                    else
                    {
                        MessageBox.Show("wrong");
                    }
                }
