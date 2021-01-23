    public List<string> GetStringList(params object[] values)
    {
        List<string> _stringList = new List<string>(); 
        foreach (object value in values)        
        {
            _stringList.Add(Convert.ToString(value));
            //Do something
        }
        return _stringList;         
    }   
