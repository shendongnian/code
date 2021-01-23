    public List<string> SomeSettingPerUser
    {
        get
        {
            return (List<string>)HttpContext.Current.Session["SomeSetting"];
        }
        set
        {
            HttpContext.Current.Session["SomeSetting"] = value;
        }
    }
