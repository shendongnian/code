    // good
    public void SendMail( string name, string address, etc etc )
    {
       // mail code here
    }
    
    // better
    public void SendMail( UserInfo info )
    {
    
    }
    // best
    public void SendMail( UserInfo info, string template )
    {
       // insert the user values into a template of some sort...no hardcoding format/HTML
    }
