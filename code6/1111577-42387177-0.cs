     void Application_Start(object sender, EventArgs e)
    {
        Application["cnt"] = 0;
        Application["onlineusers"] = 0;
        // Code that runs on application startup
    }
     void Session_Start(object sender, EventArgs e)
    {
        Application.Lock();
        Application["cnt"] = (int)Application["cnt"] + 1;
        if(Session["username"] != null)
        {
            Application["onlineusers"] = (int)Application["onlineusers"] + 1;
        }
        else
        {
            Application["onlineusers"] = (int)Application["onlineusers"] - 1;
        }
        Application.UnLock();
        // Code that runs when a new session is started
    }
