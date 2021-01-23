    void worker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
        listBox2.Items.Add(e.UserState.ToString());
        listbox2.Items.Refresh();
    }
