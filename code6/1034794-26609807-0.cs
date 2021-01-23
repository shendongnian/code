    public IQueryable<EventInstance> GetInstances(int scheduleID) 
    {
    	// only returning instances that are 3 months back
    	DateTime dateRange = DateTime.Now.AddDays(-180);
    	return EventDBContext.EventInstances.Where(x => 
    			x.CustomerID == MultiTenantID && 
    			x.StartDateTime >= dateRange && 
    			x.EventTimeInstances.Any(a => a.EventTimeID == scheudleID) ).OrderBy(x => x.StartDateTime).AsQueryable();
    }
