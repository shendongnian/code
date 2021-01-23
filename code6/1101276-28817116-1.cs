    for (int i = 0; i < List.Count; i++)
            {
    
                if (List[i].Contains(Username))
                {
                    if (List[i].Contains(hashPassword))
                    {
                        MessageBox.Show(
                         "Welcome, 
                         " + textBox1.Text + ". Logging in...", "Welcome");
                        Form.ActiveForm.Hide();
                        Main.FrontWindow Start = new Main.FrontWindow();
                        Start.ShowDialog();
                    }
    
                    else
                    {
                        label3.Text = "Username and password do not match.";
                    }
                  break;
                }
                else
                {
                    label3.Text = "User does not exist";
                }
            }
