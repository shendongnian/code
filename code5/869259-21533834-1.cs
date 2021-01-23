    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }
    private void FormLoginPage_Closing(object sender, FormClosingEventArgs e)
    {
       string exitMessageText = "Are you sure you want to exit the application?";
       string exitCaption = "Cancel";
       MessageBoxButtons button = MessageBoxButtons.YesNo;
       DialogResult res = MessageBox.Show(exitMessageText, exitCaption, button, MessageBoxIcon.Exclamation);
       if (res == DialogResult.Yes)
       {
           e.Cancel = false;
           Application.Exit();
       }
       else if (res == DialogResult.No)
       {
           e.Cancel = true;
       }
      
    }
