    public bool LoggedIn
    {
        get
        {
            return CurrentSession != null && CurrentSession.Expires > DateTime.Now;
        }
    }
