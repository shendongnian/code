    private Student StudentSession
    {
        get{ return (Student)Session["regis"]; }
        set{ Session["regis"] = value; }
    }
    
