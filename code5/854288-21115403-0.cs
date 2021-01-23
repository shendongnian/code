    private void backgroundWorker1_ProgressChanged(object sender,
        ProgressChangedEventArgs e)
    {
        MessageBoxExTn.Show(parentForm,
            e.UserState as string,
            someCaption,
            MessageBoxButtons.OK);
    }
