    public List<string> SomeArray
    {
        get
        {
            if (ViewState["SomeArray"] != null)
            {
                return (List<string>)ViewState["SomeArray"];
            }
            return null;
        }
        set { ViewState["SomeArray"] = value; }
     }
