    private void AttachActivity(Activity activity)
    {
        var activityInDb = db.Activities.Find(activity.Id);
        // Activity does not exist in database and it's new one
        if(activityInDb == null)
        {
            db.Activities.Add(activity);
            return;
        }
        // Activity already exist in database and modify it
        db.Entry(activityInDb).CurrentValues.SetValues(activity);
        db.Entry(activityInDb ).State = EntityState.Modified;
    }
