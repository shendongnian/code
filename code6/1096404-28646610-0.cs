    System.Reflection.Assembly thisExe; 
    thisExe = System.Reflection.Assembly.GetExecutingAssembly();
    string [] resources = thisExe.GetManifestResourceNames();
    string list = "";
    // Build the string of resources.
    foreach (string resource in resources)
        list += resource + "\r\n";
