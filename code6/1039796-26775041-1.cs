    // Sitecore.ContentSearch.SearchTypes.SearchResultItem
    public virtual string this[string key]
    {
    	get
    	{
    		if (key == null)
    		{
    			throw new ArgumentNullException("key");
    		}
    		return this.fields[key.ToLowerInvariant()].ToString();
    	}
    	set
    	{
    		if (key == null)
    		{
    			throw new ArgumentNullException("key");
    		}
    		this.fields[key.ToLowerInvariant()] = value;
    	}
    }
