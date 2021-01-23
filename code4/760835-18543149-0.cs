    // Original list of OEM objects
    List<asbs.OEM> Oems = new List<asbs.OEM>();
    Oems.Add(new asbs.OEM() { OemID = 7 });
    Oems.Add(new asbs.OEM() { OemID = 8 });
    Oems.Add(new asbs.OEM() { OemID = 27 });
    // Create a new dictionary from the list, using the OemIDs as keys
    Dictionary<int, asbs.OEM> dict = Oems.ToDictionary(o => o.OemID);
    // Now serialize the dictionary
    string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
