    public List<string> Types()
    {
       List<string> propTypes = new List<string>();
       foreach (var prop in typeof(WineCellar).GetProperties())
       {
           propTypes.Add(prop.PropertyType.ToString());
       }
       return propTypes ;
    }
