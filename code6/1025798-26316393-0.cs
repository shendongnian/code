    protected string UserName
    {
         string UName="";
         if(Session["Username"]!=NULL)
         UName=Session["Username"].ToString();
    
        get { return UName; }
    }
