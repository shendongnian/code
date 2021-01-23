    Dictionary<Type, string> paths = new Dictionary<TYpe, string>()
    {
        { typeof(Manager),  "ManagerHomeA" }
        { typeof(Accountant),  "AccountantHomeC" }
        { typeof(Cleaner),  "Cleaner" }
    }
    
    string path = "Home";
    if(paths.ContainsKey(x.GetType())
        path = paths[x];
