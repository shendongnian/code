    if (string.IsNullOrEmpty(this.textBox_entry_password.Text))
            {
                MessageBox.Show("Please enter a password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.textBox_entry_password.Focus();
            }
    
            else
            {
    
                // Authentication not Implemented so far
    
                Form Form2 = new Form2();
                Form2.StartPosition = FormStartPosition.CenterScreen;
    
                // Code for hiding Form3 -- Needed ????
                Form2.ShowDialog();
                this.Hide();
                form.ShowDialog();
    
            }
