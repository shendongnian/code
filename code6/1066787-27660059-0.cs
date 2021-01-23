    // don't map me
    public string SecureUserName
    {
        get { return Encrypt(UserName);
        set { UserName = Encrypt(value); }
    }
