    void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var message = e.UserState.ToString();
        var percent = e.ProgressPercentage;
        lblStatus.Text = message + " " + percent;
    }
