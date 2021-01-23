    public bool dialogOpen = false;
    public void x_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // check
        if(dialogOpen)
            return;
        dialogOpen = true;
        (new MyDialog("Something went wrong.")).ShowDialog(this);
        dialogOpen = false;
    }
