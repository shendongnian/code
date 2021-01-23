    private void UpdateUserDevices ( UserModel model )
    {
        // Get users current devices from database
        var currentDevicesFromDatabase = _deviceRepository.FindByUserId( model.Id );
        
        var devicesToAdd = model.Devices.Exclude( currentDevicesFromDatabase, d => d.Id ).ToList();
        var devicesToDelete = currentDevicesFromDatabase.Exclude( model.Devices, d => d.Id ).ToList();
        var workingDevices = model.Devices.Union( currentDevicesFromDatabase ).ToList();
        foreach ( var device in workingDevices )
        {
            if ( devicesToAdd.Contains( device ) )
            {
                // Add devices
                _deviceRepository.Create( device );
            }
            else if ( devicesToDelete.Contains( device ) )
            {
                // Delete devices
                _deviceRepository.Delete( device );
            }
            else
            {
                // Update the rest
                _deviceRepository.Update( device );
            }
        }
    }
