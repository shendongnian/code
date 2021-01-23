    Task<string> _pendingLogin = null;
    private async void buttonclick(object sender, EventArgs e)
    {
        if (_pendingLogin != null)
        {
            MessageBox.Show("Login pending...");
            return;
        }
    
        try
        {
            _pendingLogin = login(url, id, pw);
            string htmlPage = await _pendingLogin;
            MessageBox.Show("Logged in: " + htmlPage);
        }
        catch(Exception ex)
        {
            MessageBox.Show("Error in login: " + ex.Message);
        }
    
        _pendingLogin = null;
    }
