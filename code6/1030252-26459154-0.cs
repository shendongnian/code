    private void btnExit_Click(object sender, EventArgs e)
    {
        const string message = "Do you want to exit?";
        const string caption = "EXIT";
        var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
           Application.Exit();
        }
        else if (result == DialogResult.Yes)
        {
           this.Close();
        }
    }
