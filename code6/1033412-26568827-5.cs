    // Get string from registry
    // RegistryKey.OpenBaseKey(blahblahblah)
            
    var version = "32.0.1"; //Assume this string came from registry
    var parsedversion = Version.Parse(version);
    var minimumversion = new Version("33.0.1");
    if (parsedversion >= minimumversion)
        Console.WriteLine("Your version is correct");
    else
        Console.WriteLine("You need a newer version!");
