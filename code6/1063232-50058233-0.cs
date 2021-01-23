    public class UserRole
    {
      public int RoleID {get; set;}
      public string RoleName {get; set;}
      public bool Selected {get; set;}
    }
    
    public class UserSecurity
    {
      public int SecurityID {get; set;}
      public string SecurityName {get; set;}
      public bool Selected {get; set;}
    }
    
    public class UserRoleAndSecurityModel
    {
      public List<UserRole> RoleMaster {get; set;}
      public List<UserSecurity> SecurityMaster {get; set;}
    }
