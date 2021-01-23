            private void Form1_Load(object sender, EventArgs e)
            {
                this.KeyPreview = true;
            }
     
            private void button1_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    MessageBox.Show("Please enter a username and password!");
                }
                else if (IsValidUser(textBox1.Text.Trim(), textBox2.Text.Trim()))
                {
                    MessageBox.Show("Succesfully logged in!");
                    Program.ActiveUser = textBox1.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();
                }
            }
    
            private bool IsValidUser(string userName, string userPassword)
            {
                for (int i = 0; i <= Program.ProfileList.Count - 1; i++)
                {
                    if (Program.ProfileList[i].Username == userName)
                    {
                        AESEncrypt encrypt = new AESEncrypt();
                        if (Program.ProfileList[i].Password == encrypt.EncryptToString(userPassword))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
