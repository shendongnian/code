    private void mergeRepositories(UserModel model, List currentDevicesFromDatabase)
    {
    	// if both the model devices and the datbase devices have records
    	// compare them and run creates, deletes, and updates
    
    	var devicesToAdd = model.Devices.Exclude( currentDevicesFromDatabase, d => d.Id ).ToList();
    	var devicesToDelete = currentDevicesFromDatabase.Exclude( model.Devices, d => d.Id ).ToList();
    	var devicesToUpdate = model.Devices.Intersect( currentDevicesFromDatabase, d => d.Id ).ToList();
    
    	foreach( device in devicesToAdd ){
    		_deviceRepository.Create( device );
    	}
    	
    	foreach( device in devicesToDelete ){
    		_deviceRepository.Delete( device );
    	}
    	
    	foreach( device in devicesToUpdate){
    		_deviceRepository.Update( device );
    	}
    	
    	return;
    }
    	
