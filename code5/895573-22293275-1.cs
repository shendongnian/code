    List<List<string>> lStore = new List<List<string>>();
    
    //...
    
    while ((sFileContents = srFile.ReadLine()) != null)
    {
        if (sFileContents.Contains("MSH") || !lStore.Any())
        {
            // start a new record if MSH is found
            // or this is the first line being read
            lStore.Add(new List<string>());
        }
        // Append current line to last (i.e. current) record
        lStore.Last().Add(sFileContents);
    }
