    public string Username
    {
       get{ if(Session["Username"]!=null) return Session["Username"].ToString() else return String.Empty; }
       
       set{ Session["Username"] = value; }
    
    }
