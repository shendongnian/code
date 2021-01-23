    void Initialization()
    {
        // Create a dependency connection.
        SqlDependency.Start(connectionString, queueName);
    }
    
    void SomeMethod()
    {
        // Assume connection is an open SqlConnection.
    
        // Create a new SqlCommand object.
        using (SqlCommand command=new SqlCommand(
            "SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers", 
            connection))
        {
    
            // Create a dependency and associate it with the SqlCommand.
            SqlDependency dependency=new SqlDependency(command);
            // Maintain the refence in a class member.
    
            // Subscribe to the SqlDependency event.
            dependency.OnChange+=new
               OnChangeEventHandler(OnDependencyChange);
    
            // Execute the command.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Process the DataReader.
            }
        }
    }
    
    // Handler method
    void OnDependencyChange(object sender, 
       SqlNotificationEventArgs e )
    {
      // Handle the event (for example, invalidate this cache entry).
    }
    
    void Termination()
    {
        // Release the dependency.
        SqlDependency.Stop(connectionString, queueName);
    }
