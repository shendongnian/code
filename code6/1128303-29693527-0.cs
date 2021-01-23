    // Global.asax
    public void Session_OnStart()
    {
      Session["GUIDSessionID"] = Guid.NewGuid().ToString();
    }
