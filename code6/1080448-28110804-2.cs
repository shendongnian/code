    private async void btnAnalyze_Click(object sender, EventArgs e)
    {
        OWConnector api = new OWConnector(@"http://mywebsite.com/");
        Boolean didAuth = await api.authAsync("myuser", "mypass");
        if (didAuth)
        {
            MessageBox.Show(@"success :)");
        }
        else
        {
             MessageBox.Show(@"failed :(");
        }
    }
