    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        IsCopyComplete = true;
        button1.Invoke(new Action(() => button1.Enabled = true));
    }
