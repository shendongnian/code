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
            // Maintain the reference in a class member.
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
