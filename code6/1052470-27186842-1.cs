    public bool? IsMobile
    {
        get
        {
            return HttpContext.Current.Session["ismobile"] as bool?;
        }
        set
        {
            HttpContext.Current.Session["ismobile"] = value;
        }
    }
