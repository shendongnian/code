    public void Session_OnStart()
    {
    Application.Lock();
        if (Application["UsersOnline"] == null )
        {
           Application["UsersOnline"] = 0
         }
    Application["UsersOnline"] = (int)Application["UsersOnline"] + 1;
    Application.UnLock();
}
