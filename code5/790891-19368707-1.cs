    private void UpdateUserDevices( UserModel model )
    {
        // Get users current devices from database
        var currentDevicesFromDatabase = _deviceRepository.FindByUserId( model.Id ).ToList();
        var devicesToAdd = model.Devices.Exclude( currentDevicesFromDatabase, d => d.Id ).ToList();
        var devicesToDelete = currentDevicesFromDatabase.Exclude( model.Devices, d => d.Id ).ToList();
        var devicesToUpdate = model.Devices.Where(d => currentDevicesFromDatabase.Contains(d) );
        foreach( var device in devicesToAdd )
            _deviceRepository.Create( device );
        foreach( var device in devicesToRemove)
            _deviceRepository.Delete( device );
        foreach( var device in devicesToUpdate )
            _deviceRepository.Update( device );
    }
