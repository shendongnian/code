    public override void Validate(string userName, string password)
    {
        if(String.IsNullOrEmpty(userName) && String.IsNullOrEmpty(password))
        {
            // Allow anonymous access here.
            return;
        }
        // Allow/deny users that provide credentials
        ValidateOtherCredentials(userName, password);
    }
