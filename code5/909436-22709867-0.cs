    NetworkChange.NetworkAvailabilityChanged += (sender, networkAvailabilityEventArgs) =>
        {
            if (networkAvailabilityEventArgs.IsAvailable)
            {
                // Network is available
                // Try to open a database connection
            }
            else
            {
                // Network is not available
                // Stop trying to open a database connection, or clean up existing connections
            }
        };
