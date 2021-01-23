    private void UpdateUserDevices( UserModel model )
    {
        // Get users current devices from database
        var currentDevicesFromDatabase = _deviceRepository.FindByUserId( model.Id ).ToList();
    
    	$isUserDevicesEmpty = !model.Devices.Any();
    	$isRepositoryEmpty = !currentDevicesFromDatabase.Any();
    	
    	if($isRepositoryEmpty || $isUserEmpty){
    		// Missing One
    		if($isRepositoryEmpty){
    			this.deleteEmpty(currentDevicesFromDatabase);
    		}
    		
    		if($isUserDevicesEmpty){
    			this.deleteEmpty(model.Devices);
    		}
    	}
    	else{
    		this.mergeRepositories(currentDevicesFromDatabase, model);
        }
       
        return;
    }
    
