    var versionString = "6.4.0.1";
    Version version;
    if (Version.TryParse(versionString, out version))
    {
        // Here you get your 4
        Debug.WriteLine("The version Integer is " + version.Minor);  
    }
    else
    {
        // Here you should do your error handling
        Debug.WriteLine("Invalid version string!"); 
    }
