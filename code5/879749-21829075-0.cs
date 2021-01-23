    public IQueryable<ActivityLog> ApplyCriteria()
    {
        var activitySet = db.ActivityLog.AsQueryable();
        if(!string.IsNullOrWhiteSpace(deviceName))
            activitySet.Where(c => c.Devices.devName.ToLower().Contains(devicename.ToLower());
    
        //and so on and so forth
        return activitySet;
    }
