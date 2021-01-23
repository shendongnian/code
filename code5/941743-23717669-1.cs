    public void ClosingFunction (object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (MyMsgBox.Show("Are you sure you want to exit withou saving?", "Exit") == false)
        {
            e.Cancel = true; // Cancel the closing event
            return;
        }
    }
