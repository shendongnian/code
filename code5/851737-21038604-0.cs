    public async void LoginButtonClicked()
    {
        await Remote.LoginAsync("user","password");
        // do anything else required
    }
