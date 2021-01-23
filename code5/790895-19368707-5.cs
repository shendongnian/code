    private void UpdateUserDevices ( UserModel model )
    {
        var currentDevicesFromDatabase = _deviceRepository.FindByUserId( model.Id );
        // Take the current model and remove all items from the database... This leaves us with only records that need to be added.
        var devicesToAdd = model.Devices.Exclude( currentDevicesFromDatabase, d => d.Id ).ToList();
        // Take the database and remove all items from the model... this leaves us with only records that need to be deleted
        var devicesToDelete = currentDevicesFromDatabase.Exclude( model.Devices, d => d.Id ).ToList();
        // Take the current model and remove all of the items that needed to be added... this leaves us with only updateable recoreds
        var devicesToUpdate = model.Devices.Exclude(devicesToAdd, d => d.Id).ToList();
        foreach ( var device in devicesToAdd )
            _deviceRepository.Create( device );
        foreach ( var device in devicesToDelete )
            _deviceRepository.Delete( device );
        foreach ( var device in devicesToUpdate )
            _deviceRepository.Update( device );
    }
