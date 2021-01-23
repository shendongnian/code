    public void setRolePermissions(int role, List<int> permissions)
    {
        var roleToUpdate = _context.Roles.Find(role);
        _context.Entry(roleToUpdate).Collection("Permissions").Load(); // load explicitly here
        foreach (int item in permissions)
        {
            Permission permission = (Permission)getPermissionsByid(item);
            roleToUpdate.Permissions.Remove(permission);
        }    
        
        _context.SaveChanges();
    {}
