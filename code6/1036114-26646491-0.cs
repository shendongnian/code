    public override string[] GetRolesForUser(string username)
    {
        DEV_Context OE = new DEV_Context();
        string role = OE.UserRefs.Where(x => x.UserName == username).FirstOrDefault().RoleName;
        string[] result= OE.RolePermissionRefs.Where(x => x.RoleName == role).Select(x=>x.FunctionCode).ToArray(); 
        
        return result;
    }
