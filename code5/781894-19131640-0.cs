    private bool GetPermission(string email) {
        var user = SomeMembershipService.GetUser(email); 
        var roles = SomeMembershipService.GetRoles(user.Id);
    
        bool result = false;
        if (roles != null) {
            var adm = roles.FirstOrDefault(x => x.Name.Contains("Admin"));
            result = adm != null;
        }
        return result;
    }
