    void SaveActivity(IActivity activity)
    {
     ...
     if(activity is EngagementActivity)
     {
       // use explicit type casting '(EngagementActivity)activity' and get your properties
       return;
     }
     if(activity is MPEngagementActivity)
     {
       // use explicit type casting '(MPEngagementActivity)activity' and get your properties
       return;
     }
     ...
    }
