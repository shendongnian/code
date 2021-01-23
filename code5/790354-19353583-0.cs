    public virtual void WriteLine(string message, string category)
    {
    	if (Filter != null && 
            !Filter.ShouldTrace(null, "", TraceEventType.Verbose, 0, message))
    	{
    		return;
    	}
    	if (category == null)
    	{
    		WriteLine(message);
    		return;
    	}
    	WriteLine(category + ": " + ((message == null) ? string.Empty : message));
    }
