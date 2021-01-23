    public async void DoSomething ()
    {
        StartActivityIndicator();
        authenticateBtn.Enabled = false;
        authenticateBtn.BackgroundColor = UIColor.Gray;
        bool isValid = ValidateTextbox ();
        if (isValid)
            await CreateUserAccount ();
        StopActivityIndicator (); 
    }
