    private void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.textBox_entry_password.Text))
        {
            MessageBox.Show("Please enter a password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            this.textBox_entry_password.Focus();
        }
        else
        {
            // Authentication code here
            // if (isAuthenticated)
            // {
            //     DialogResult = DialogResult.OK;
            //     Close(); // hides and closes the form
            // }
         }
    }
