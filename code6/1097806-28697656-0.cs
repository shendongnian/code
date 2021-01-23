    private T GetValue<T>(object obj, string property)
    {
    	return (T)obj.GetType()
                     .GetProperties()
                     .Single(p => p.Name == property)
                     .GetValue(obj);
    }
