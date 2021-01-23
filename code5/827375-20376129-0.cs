    private void buLogOptions_Click(object sender, EventArgs e)
    {
        logOptionsForm logForm = new logOptionsForm();
        logForm.ShowDialog();
        
        if (logForm.IsDoneClicked)
        {
            logForm.Nud = //do whatever you want with Nud
        }
    }
