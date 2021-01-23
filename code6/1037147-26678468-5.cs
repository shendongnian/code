    private async Task Authenticate(CancellationToken cancellationToken)
    {
        ....
        bool loggedInOk= await Security.ProcessLogin(txtUsername.Text,txtPassword.Text);
        if (cancellationToken.IsCancellationRequested)
        {
            // do something here as task was cancelled mid flight maybe just
            return;
        }
        if (loggedInOk)
        {
            StartActivity(typeof(actMaiMenu));
            this.Finish();
        }
        else
        {
            \\Warn User
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.RequestFocus();
        }
    }
