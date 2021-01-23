    public IQueryable<ActivityLog> ApplyCriteria(Context db)
    {
        var activitySet = db.ActivityLog.AsQueryable();
        if(!string.IsNullOrWhiteSpace(deviceName))
            activitySet.Where(c => c.Devices.devName.ToLower().Contains(devicename.ToLower());
    
        //and so on and so forth
        return activitySet;
    }
    public Response SearchStuff(Criteria criteria)
    {
        using(var db = CreateContext())
        {
            var qry = criteria.ApplyApplyCriteria(db);
            //In this instance, whatever is a list on my response object, but I believe it could be
            //anything that handles IEnumerable
            response.Whatever.AddRange(qry);
        }
    }
    
