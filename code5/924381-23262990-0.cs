    public static int StartProcess(string machineName, string processPath, ManagementScope connnectionScope, int timeout)
    {
        ManagementClass processTask = new ManagementClass(@"\\" + machineName + @"\root\CIMV2",
                                                                        "Win32_Process", null);
        processTask.Scope = connnectionScope;
        ManagementBaseObject methodParams = processTask.GetMethodParameters("Create");
        methodParams["CommandLine"] = processPath;
        InvokeMethodOptions options = new InvokeMethodOptions();
        options.Timeout = TimeSpan.FromSeconds(timeout);
        ManagementBaseObject exitCode = processTask.InvokeMethod("Create", methodParams, null);
    
        return Convert.ToInt32(exitCode["ReturnValue"].ToString());
    }
