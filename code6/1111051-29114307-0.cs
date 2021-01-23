    static void Extract(dynamic dd)
    {
        string name;
        if (dd.GetType().IsArray)
        {
            name = dd[0].Name;
        }
        else
        {
            name = dd.Name;
        }
    }
