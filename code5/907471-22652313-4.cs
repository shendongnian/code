    // Create a New Instance of the Class
    var keyDetails = new RootClass();
    keyDetails.key = new List<KeyClass>();
    
    // Assign values to the Key property
    keyDetails.key.Add(new KeyClass
                            {
                                KeyValue = "22.wav",
                                index = new List<int> { 1, 2, 3}
                            });
    
    keyDetails.key.Add(new KeyClass
    {
        KeyValue = "EFG.wav",
        index = new List<int> { 5 , 22 }
    });
    
    // Generate XML
    SerializeXML(keyDetails);
