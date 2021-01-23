    public void Copy(TEntityType from, TEntityType to)
    {
    	if (from == null)
    	{
    		throw Error.ArgumentNull("from");
    	}
    	if (to == null)
    	{
    		throw Error.ArgumentNull("to");
    	}
    	this.SetValue(to, this.GetValue(from));
    }
