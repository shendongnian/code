    public virtual void SaveActivity(IActivity activity)
    {
        ...
        // some common code for all types
        if(activity is EngagementActivity)
        {
           // use explicit type casting '(EngagementActivity)activity' and get your properties
           // save your data
           return;
        }
        if(activity is MPEngagementActivity)
        {
           // use explicit type casting '(MPEngagementActivity)activity' and get your properties
           // save your data
           return;
     }
     // other activity types
     ...
     // if no case fired save data for common activity or throw exception for unknown type
    }
