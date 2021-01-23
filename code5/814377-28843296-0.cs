    Dictionary<string, PropertyInfo> _PropertyIndex = new Dictionary<string, PropertyInfo>();
    Type thisType = typeof(Client);
    foreach (PropertyInfo pi in thisType.BaseType.GetProperties())
        _PropertyIndex.Add(pi.Name.ToUpper(), pi);
    foreach (PropertyInfo pi in thisType.GetProperties())
        if( !_PropertyIndex.ContainsKey(pi.Name.ToUpper()))
            _PropertyIndex.Add(pi.Name.ToUpper(), pi);
