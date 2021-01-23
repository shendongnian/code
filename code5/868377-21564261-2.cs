    public AdminAuthorize : MyAuthorize 
    { 
       public AdminAuthorize() 
       { 
          base.Roles = new[] { Roles.UserAdmin, Roles.SuperAdmin };
       }
    }
