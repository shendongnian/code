    ConnectionOptions connection = new ConnectionOptions();
    connection.Authentication = System.Management.AuthenticationLevel.PacketPrivacy;
    ManagementScope scope =
        new ManagementScope(@"\\SOMEREMOTESERVER\root\MicrosoftIISV2",
                            connection);
    scope.Connect();
    ObjectQuery query = new ObjectQuery("SELECT * FROM IISWebServerSetting");
    var collection = new ManagementObjectSearcher(scope, query).Get();
    foreach (ManagementObject item in collection)
    {
        var value = item.Properties["ServerBindings"].Value;
        if (value is Array)
        {
            foreach (ManagementBaseObject a in value as Array)
            {
                Console.WriteLine(a["Hostname"]);
            }
        }
        ManagementObject maObjPath = new ManagementObject(item.Scope,
        new ManagementPath(
        string.Format("IISWebVirtualDirSetting='{0}/root'", item["Name"])),
        null);
        PropertyDataCollection properties = maObjPath.Properties;
        Console.WriteLine(properties["path"].Value);
        Console.WriteLine(item["ServerComment"]);
        Console.WriteLine(item["Name"]);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
