    Dictionary<Type, string> paths = new Dictionary<TYpe, string>()
    {
        { typeof(Manager),  ManagerHomeA }
        { typeof(Accountant),  ManagerHomeA }
        { typeof(Cleaner),  ManagerHomeA }
    }
    
    string path = "Home";
    if(paths.ContainsKey(x.GetType())
        path = paths[x];
