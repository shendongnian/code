    // Method call leading to the issue (definition in Collection Object class)
    // Fetch service object using the Service ID from the DB                      
    Service service = collectionObject.GetServiceByIDFromDictionary(servID);
    
    lock (service)
    {    
        // Call a Service class method        
        service.InitLanes.Add(new Service.LaneNode(currLoc.SequentialID,
                              currLocBreakFlag, nextLoc.SequentialID,
                              nextLocBreakFlag, seq));
    }
  
