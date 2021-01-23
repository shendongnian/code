    Guid existingRoleId = new Guid("C85F0FFF-4C80-E211-A877-1CC1DE79B4CA");
    Guid newRoleId = new Guid("B6690FFF-4C80-E211-A877-1CC1DE79B4CA");
    // Step 2
    RetrieveRolePrivilegesRoleRequest getPrivilagesRequest = 
                     new RetrieveRolePrivilegesRoleRequest();
    getPrivilagesRequest.RoleId = existingRoleId;
    RetrieveRolePrivilegesRoleResponse privilagesResponse = 
             (RetrieveRolePrivilegesRoleResponse)service.Execute(getPrivilagesRequest);
    if (privilagesResponse != null && privilagesResponse.RolePrivileges != null)
    {
        // Step 3
        AddPrivilegesRoleRequest addPrivilagesRequest = new AddPrivilegesRoleRequest();
        addPrivilagesRequest.Privileges = privilagesResponse.RolePrivileges;
        addPrivilagesRequest.RoleId = newRoleId;
        AddPrivilegesRoleResponse addPrivilagesResponse = 
                (AddPrivilegesRoleResponse)service.Execute(addPrivilagesRequest);
    }
