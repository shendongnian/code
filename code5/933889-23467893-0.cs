    public Dictionary<int, List<MyClass>> list
    {
        get
        {
            if (Session["SessionName"] == null)
            {
                Session["SessionName"] = new Dictionary<int, List<MyClass>>();
            }
            return Session["SessionName"] as Dictionary<int, List<MyClass>>;
        }
        set
        {
            Session["SessionName"] = value;
        }
    }
