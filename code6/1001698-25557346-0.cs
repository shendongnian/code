    var RoleAPI = new Ektron.Cms.API.Content.Content().EkContentRef;
        
    // Get all custom roles (careful, as the first item in my test was null)
    var roles = RoleAPI.GetAllRolePermissions();
    // This will eliminate returned nulls.
    var names = roles.Where(r => r != null).Select(r => r).ToArray();
        
    // Check whether a user is a member of the role.
    var isAMember = RoleAPI.IsARoleMember(1002, 10);
    
    // Add a new custom role.
    RoleAPI.AddRolePermission("Membership Group Admin");
    
    // Add a user to a role.
    var member = new RoleMemberData()
    {
        MemberId = 10,
        // Even membership users are type = User.
        MemberType = RoleMemberData.RoleMemberType.User
    };
    RoleAPI.AddRoleMember(1002, ref member);
            
    // Remove a user from a role (using member as defined above).
    RoleAPI.DropRoleMember(1002, ref member);
