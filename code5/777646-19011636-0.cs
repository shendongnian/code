    ConnectionOptions options = new ConnectionOptions();
    options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
    options.Username = serverDomain + "\\" + serverUser;
    options.Password = serverPassword;
    ManagementScope scope = new ManagementScope("\\\\" + serverName + "\\root\\cimv2", options);
    Console.WriteLine("Connecting to scope");
    scope.Connect();
    Console.WriteLine("Getting ManagementPath");
    ManagementPath servicePath = new ManagementPath("Win32_Service.Name='" + serviceName + "'");
    Console.WriteLine("Getting ManagementObject");
    ManagementObject serviceObj = new ManagementObject(scope, servicePath, new ObjectGetOptions());
    Console.WriteLine("Name of service is " + serviceObj["DisplayName"].ToString());
    Console.WriteLine("Process ID of service is " + serviceObj["ProcessId"].ToString());
                
    // use processid to kill process with taskkill
    ObjectGetOptions processObjGetOpt = new ObjectGetOptions();
    ManagementPath processPath = new ManagementPath("Win32_Process");
    ManagementClass processClass = new ManagementClass(scope, processPath, processObjGetOpt);
    ManagementBaseObject processInParams = processClass.GetMethodParameters("Create");
    processInParams["CommandLine"] = string.Format("cmd /c \"taskkill /f /pid {0}\"", serviceObj["ProcessId"].ToString());
    ManagementBaseObject outParams = processClass.InvokeMethod("Create", processInParams, null);
    Console.WriteLine("Return code for taskkill: " + outParams["returnValue"]);
    int returnCode = System.Convert.ToInt32(outParams["returnValue"]);
