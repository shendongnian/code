    string comp = "Computer";
    ConnectionOptions options = new ConnectionOptions();
    //user (domain or local) with sufficient privileges to access the remote system through WMI
    options.Username = "Usersname"; 
    options.Password = "Password";
    ManagementScope s = new ManagementScope(string.Format(@"\\{0}\root\cimv2", comp), options);
            
    ManagementPath p = new ManagementPath(string.Format("Win32_ComputerSystem.Name='{0}'", comp));
    using(ManagementObject cs = new ManagementObject (s, p, null ))
    {
        cs.Get();
        Console.WriteLine(cs["UserName"]);
    }
