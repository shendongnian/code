    private void UpdateUserDevices( UserModel model )
    {
      // Get users current devices from database
      var currentDevicesFromDatabase = _deviceRepository.FindByUserId( model.Id ).ToList();
        var devicesToAdd = model.Devices.Exclude( currentDevicesFromDatabase, d => d.Id ).ToList();
        var devicesToDelete = currentDevicesFromDatabase.Exclude( model.Devices, d => d.Id ).ToList();
        var workingDevices = model.Devices.Union( currentDevicesFromDatabase );
        foreach( var device in workingDevices )
        {
            // Add devices
            if( devicesToAdd.Contains( device ) )
            {
                _deviceRepository.Create( device );
                continue;
            }
            // delete devices
            if( devicesToDelete.Contains( device ) )
            {
                _deviceRepository.Delete( device );
                continue;
            }
            // update the rest
            _deviceRepository.Update( device );
        }
    }
