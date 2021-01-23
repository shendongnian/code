    var allNames = NameApiService.GetAllNames();
	GenericAddOrUpdate(allNames, "BusinessSystemId", "NameNo");
    public virtual void GenericAddOrUpdate<T>(IEnumerable<T> values, params string[] keyValues) where T : class
    {
        foreach (var value in values)
        {
            try
            {
                var keyList = new List<object>();
                //Get key values from T entity based on keyValues property
                foreach (var keyValue in keyValues)
                {
                    var propertyInfo = value.GetType().GetProperty(keyValue);
                    var propertyValue = propertyInfo.GetValue(value);
                    keyList.Add(propertyValue);
                }
                GenericAddOrUpdateDbSet(keyList, value);
                //Only use this when debugging to catch save exceptions
                //_dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        _dbContext.SaveChanges();
    }
	
	public virtual void GenericAddOrUpdateDbSet<T>(List<object> keyList, T value) where T : class
    {
        //Get a DbSet of T type
        var someDbSet = Set(typeof(T));
        //Check if any value exists with the key values
        var current = someDbSet.Find(keyList.ToArray());
        if (current == null)
        {
            someDbSet.Add(value);
        }
        else
        {
            Entry(current).CurrentValues.SetValues(value);
        }
    }
