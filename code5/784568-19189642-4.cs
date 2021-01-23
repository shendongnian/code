    private void MainForm_Load(object sender, EventArgs e)
    {
        this.Visible = false;
        using (var loginForm = new LoginForm())
        {
            if (loginForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Visible = true;
            }
            else
            {
                // Error handling
                Close();
            }
        }
    }
