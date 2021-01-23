    internal void AddUser(string user)
    {
        Collection<string> source = new Collection<string>();
        try
        {
            foreach (string str in this._users)
            {
                source.Add(str);
            }
        }
        catch (Exception)
        {
        }
        if (!source.Contains(user))
        {
            source.Add(user);
        }
        this._users = null;
        this._users = source.ToArray<string>();
    }
 
