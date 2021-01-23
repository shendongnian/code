    public void UseWCFMethod()
    {
      String roleName = "Admin";
      
      RoleMemberInfo info = new RoleMemberInfo();
      info.UserOrGroupId = "1";
      info.DirectoryService = "Default";
    
      wcfProxy.AddToRole(roleName, info);
    }
