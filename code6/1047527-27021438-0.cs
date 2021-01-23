    public bool Get(string user, string pass)
    {
        Authenticate(user, pass);
        return loggedin;
    }
