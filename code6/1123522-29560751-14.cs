    private IMember _Owner;
    public IMember Owner
    {
    	get { return _Owner; }
    	set
    	{
    		_Owner = value;
    		foreach (var member in this)
    		{
    			member.Parent = value;
    		}
    	}
    }
    
    public void Add(IMember item)
    {
    	item.Parent = Owner;
    	base.Add(item);
    }
