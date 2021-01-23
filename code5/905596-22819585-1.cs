    public void dependency_OnDataChangedDelegate(object sender, SqlNotificationEventArgs e)
    {
        SqlDependency dependency = sender as SqlDependency;
    
        dependency.OnChange -= dependency_OnDataChangedDelegate;
    
        // Fire the event
        if (OnNewMessage != null)
        {
            OnNewMessage();
        }
    }
