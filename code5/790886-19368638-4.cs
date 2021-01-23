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
