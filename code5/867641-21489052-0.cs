    private Dictionary<string, string> errors = new Dictionary<string, string>();
    public virtual string Error
    {
    	get { return String.Join(Environment.NewLine, errors); }
    }
    
    public bool HasErrors
    {
    	get
    	{
    		return errors.Count > 0;
    	}
    }
    
    public string this[string propertyName]
    {
    	get
    	{
    		string result;
    		errors.TryGetValue(propertyName, out result);
    		return result;
    	}
    }
    
    protected void SetError<T>(Expression<Func<T>> prop, String error)
    {
    	String propertyName = PropertySupport.ExtractPropertyName(prop);
    
    	if (error == null)
    		errors.Remove(propertyName);
    	else
    		errors[propertyName] = error;
    
    	OnHasErrorsChanged();
    }
    protected string GetError<T>(Expression<Func<T>> prop, String error)
	{
		String propertyName = PropertySupport.ExtractPropertyName(prop);
		String s;
		errors.TryGetValue(propertyName, out s);
		return s;
	}
    
    protected virtual void OnHasErrorsChanged()
    {
    
    }
