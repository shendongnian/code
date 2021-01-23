    var userToken = IntPtr.Zero;
    
    var success = Native.LogonUser(
      "username", 
      "domain", 
      "password", 
      2, // LOGON32_LOGON_INTERACTIVE
      0, // LOGON32_PROVIDER_DEFAULT
      out userToken);
    
    if (!success)
    {
      throw new SecurityException("User logon failed");
    }
    
    var identity = new WindowsIdentity(userToken);
    if(identity.Groups.Any(x => x.Value == "Group ID")) 
    {
        // seems to be in the group!
    } 
