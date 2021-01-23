    RootControlDispatcher.Invoke((Action)(() =>
    {
    	// Load all Roles and asks the user to choose. 
    	SecurityRoleSelector selFrm = new SecurityRoleSelector();
    	if (selFrm.RolesDataModel != null)
    	{
    		selFrm.RolesDataModel.items.Clear();
    		// Get the items for the control. 
    		SearchFilter.Clear();
    		var sL = rslts.Values.OrderBy(w => CrmSvc.GetDataByKeyFromResultsSet<string>(w, "name"));
    		foreach (var rol in sL)
    		{
    			selFrm.RolesDataModel.items.Add(new CrmSecurityRoles()
    			{
    				RoleId = CrmSvc.GetDataByKeyFromResultsSet<Guid>(rol, "roleid"),
    				RoleName = CrmSvc.GetDataByKeyFromResultsSet<string>(rol, "name")
    			});
    		}
    		if (selFrm.ShowDialog().GetValueOrDefault(false))
    		{
    			// user selected an item. 
    			if (selFrm.RolesControl.cbSelectedItem.SelectedItem != null)
    			{
    				CrmSecurityRoles role = (CrmSecurityRoles)selFrm.RolesControl.cbSelectedItem.SelectedItem;
    				guCSRManagerRoleId = role.RoleId;
    			}
    		}
    	}
    	selFrm.Close(); // Clean up form. 
    }), DispatcherPriority.Normal , null);
