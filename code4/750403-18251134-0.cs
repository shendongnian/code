    StatusCode CreateResource_Internal(string name, string type)
    {
    	try
        {
    		Trace.LogEvent("BEGIN CreateResource name=" + name + " type=" + type);
    		StatusCode status = StatusCode.Ok;
        
            if (!IsValidResourceName(name))
            {
                status = StatusCode.InvalidName;
                return status;
            }
            if (!IsValidResourceType(type))
            {
                status = StatusCode.InvalidType;
                return status;
            }
            if (!SystemOnline())
            {
                status = StatusCode.SystemOffline;
                return status;
            }
    		status = StatusCode.Ok; // A bit silly, but that avoids the problem of status not being set.
    		return status;
        }
        finally
        {
            Trace.LogEvent("END CreateResource result=" + status);
        }
    }
