     public dynamic GiveRolesWhichAreNotAssignedToThisUser(String token, String selectedUser, String selectedOrganization)
        {
            User u = InstaFood.Core.User.Get(selectedUser);
            var allRoles = RolesType.GetByOrganizationType(selectedOrganization).Select(i => new
            {
                ID = i.Id,
                Name = i.Name
            });
    
            var alreadyHaveRoles = u.GetUserRoles().Select(i => new
            {
                ID = i.roleTypeId,
                Name = ""        
            });
    
            return allRoles.Where(i=>!alreadyHaveRoles.Contains(i));
        }
