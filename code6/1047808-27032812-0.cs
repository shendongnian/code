    private async Task AddPermissions(DataContext context)
    {
        var permissionService = new PermissionService(context);
    	
    	List<Task> permissionRequests = new List<Task>();
    	
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanView", "View company")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanAdd", "Add and view company")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanEdit", "Edit and view company")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanDelete", "Delete and view company record")));
    
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanAdd", "Add new pages")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanEdite", "Edit existing pages")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanDelete", "Delete a page")));
    
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanAdd", "Add new page content")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanEdit", "Edit existing page content")));
        permissionRequests.Add(permissionService.AddAsync(new Permission("CanDelete", "Delete page content")));
    	
    	await Task.WhenAll(permissionRequests);
    }
