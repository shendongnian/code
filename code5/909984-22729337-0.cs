    Dictionary<string, string> values = new Dictionary<string, string>();
    // read the xml file on start up populate the dictionary.
    
    // after that, every Dictionary access will be O(1)
    string value = values["OfficeEmail"];
