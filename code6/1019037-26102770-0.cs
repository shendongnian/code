    public override void SaveActivity(IActivity activity)
    {
        var engagementActivity = activity as EngagementActivity;
        if (engagementActivity != null) // it's the correct type
        {
            // Do whatever's needed here
        }
    }
