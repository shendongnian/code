    // get hardware token
    HardwareToken token = HardwareIdentification.GetPackageSpecificToken(null);
    // get hardware ID bytes
    byte[] idBytes = hwToken.Id.ToArray();
    // populate device ID as a string value
    string deviceID = string.Join(",", idBytes); 
