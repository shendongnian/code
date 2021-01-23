    public static List<int> _list;
    public static List<int> List
    {
        get { return _list ?? (_list = new List<int>()); }
        set { _list = value; }
    }
