    public int last
    {
        get 
        { 
            if (Session["last"] != null) 
                return (int)Session["last"]; 
            return 0;
        }
        set { Session["last"] = value; }
    }
