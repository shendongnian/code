    ConnectionOptions remoteConnectionOptions = new ConnectionOptions();
    remoteConnectionOptions.Impersonation = ImpersonationLevel.Impersonate;
    remoteConnectionOptions.EnablePrivileges = true;
    remoteConnectionOptions.Authentication = AuthenticationLevel.Packet;
    remoteConnectionOptions.Username = strDomain + @"\" + strUsername;
    remoteConnectionOptions.SecurePassword = secPassword;
        
    ManagementScope scope = new ManagementScope(@"\\" + strServername + @"\root\CIMV2", remoteConnectionOptions); ManagementPath p = new ManagementPath("Win32_Process");
        
    ManagementClass classInstance = new ManagementClass(scope, p, null); object[] theProcessToRun = { "myExecutable.exe" };
        
    classInstance.InvokeMethod("Create", theProcessToRun);
