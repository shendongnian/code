    //returns a list of propertyInfo objects for the class 
    // with all kinds of usefull information
    public List<PropertyInfo> GetMemberInfos()
    {
        return this.GetType().GetProperties().ToList();
    }
    //returns a list of property names
    public List<string> GetMemberNames
    {
        return this.GetType().GetProperties().Select(pi => pi.Name).ToList();
    }
    //returns a list of names of the property types
    public List<string> GetMemberTypeNames
    {
        return this.GetType().GetProperties().Select(pi => pi.PropertyType.Name).ToList();
    }
    //indexer that uses the property name to get the value
    //since you are mixing types, you can't get more specific than object
    public object this[string property]
    {
      get { return this.GetType().GetProperty(property).GetValue(this); }
      set { this.GetType().GetProperty(property).SetValue(this, value); }
    }
    //indexer that uses the property index in the properties array to get the value
    public object this[int index]
    {
      get { return this.GetType().GetProperties()[index].GetValue(this); }
      set { this.GetType().GetProperties()[index].SetValue(this, value); }
    }
