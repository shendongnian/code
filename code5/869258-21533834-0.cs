    private void cancelButton_Click(object sender, EventArgs e)
    {
        Close();
        if(IsClosing)
           Application.Exit();
    }
