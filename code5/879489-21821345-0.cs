    public void Save()
    {
        if (Session.IsNewSession)
        {
            throw new Exception("This session was just created.");
        }
        //Go on with save matter...
    }
