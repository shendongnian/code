    Person.FirstName = "John";
    Task.Factory.StartNew( () => {
        foreach (string mlsNumber in ourMlses) 
        { 
            Listing listing = sourceSite.ParseByMls(mlsNumber); 
            if (listing != null) 
            { 
                var successDb = sourceSite.UpdateListing(listing); 
                if (!successDb) 
                { 
                    throw new Exception("Db error"); 
                } 
       
                Dispatcher.BeginInvoke( () => {
    
                    // UI update that listing have been added to the DB 
                });
            }
        }
    } );
