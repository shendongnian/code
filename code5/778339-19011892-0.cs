    public UrlType UrlPattern
    {
        get
        {
            if (ViewState["UrlPattern"] != null)
                return (UrlType)Enum.Parse(typeof(UrlType), ViewState["UrlPattern"].ToString());
            return UrlType.Normal; // Default value
        }
        set
        {
            ViewState["UrlPattern"] = value;
        }
    }
