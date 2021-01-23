    try
    {
    string pc = "pcname";
    //string domain = "yourdomain";
    //ConnectionOptions connection = new ConnectionOptions();
    //connection.Username = some username;
    //connection.Password = somepassword;
    //connection.Authority = "ntlmdomain:" + domain;
    string wmipath = string.Format("\\\\{0}\\root\\CIMV2", pc);
    //ManagementScope scope = new ManagementScope(
    //    string.Format("\\\\{0}\\root\\CIMV2", pc), connection);
    ManagementScope scope = new ManagementScope(wmipath);
    scope.Connect();
    ObjectQuery query = new ObjectQuery(
        "SELECT * FROM Win32_LocalTime");
    ManagementObjectSearcher searcher =
        new ManagementObjectSearcher(scope, query);
    foreach (ManagementObject queryObj in searcher.Get())
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Win32_LocalTime instance");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Date: {0}-{1}-{2}", queryObj["Year"], queryObj["Month"], queryObj["Day"]);
        Console.WriteLine("Time: {0}:{1}:{2}", queryObj["Hour"], queryObj["Minute"], queryObj["Second"]);
    }
    }
    catch (ManagementException err)
    {
    Console.WriteLine("An error occurred while querying for WMI data: " + err.Message);
    }
    catch (System.UnauthorizedAccessException unauthorizedErr)
    {
    Console.WriteLine("Connection error (user name or password might be incorrect): " + unauthorizedErr.Message);
    }
