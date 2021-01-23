    using (SqlCommand command=new SqlCommand("select AccountNumber from Account", connection))
    {
        // Create a dependency and associate it with the SqlCommand.
        SqlDependency dependency=new SqlDependency(command);
     
        // Subscribe to the SqlDependency event.
        dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);
        // Execute the command.
        using (SqlDataReader reader = command.ExecuteReader())
        {
            // As you already have for first update
        }
    }
    
    void OnDependencyChange(object sender, SqlNotificationEventArgs e )
    {
       // Clear and re-add
    }
