    // Event handler for the GeoCoordinateWatcher.StatusChanged event.
    void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
    {
        switch (e.Status)
        {
            case GeoPositionStatus.Disabled:
                // The Location Service is disabled or unsupported.
                // Check to see whether the user has disabled the Location Service.
                if (watcher.Permission == GeoPositionPermission.Denied)
                {
                    // The user has disabled the Location Service on their device.
                    statusTextBlock.Text = "you have this application access to location.";
                }
                else
                {
                    statusTextBlock.Text = "location is not functioning on this device";
                }
                break;
    
            case GeoPositionStatus.Initializing:
                // The Location Service is initializing.
                // Disable the Start Location button.
                startLocationButton.IsEnabled = false;
                break;
    
            case GeoPositionStatus.NoData:
                // The Location Service is working, but it cannot get location data.
                // Alert the user and enable the Stop Location button.
                statusTextBlock.Text = "location data is not available.";
                stopLocationButton.IsEnabled = true;
                break;
    
            case GeoPositionStatus.Ready:
                // The Location Service is working and is receiving location data.
                // Show the current position and enable the Stop Location button.
                statusTextBlock.Text = "location data is available.";
                stopLocationButton.IsEnabled = true;
                break;
        }
    }
