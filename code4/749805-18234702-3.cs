    public List<string> Members()
    {
       List<string> propNames = new List<string>();
       foreach (var prop in typeof(WineCellar).GetProperties())
       {
           propNames.Add(prop.Name);
       }
       return propNames;
    }
