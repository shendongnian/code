    public void Session_OnStart()
    {
        Application.Lock();
        Application["UsersOnline"] = (int)Application["UsersOnline"] + 1;
        // At this position, execute an SQL command to update the value
        Application.UnLock();
    }
