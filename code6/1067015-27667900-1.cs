    private async Task PopulateRoles()
    {
         var roles = new[] { "A", "B", "C", "D" };
        
         foreach (var role in roles)
         {
             await _roleService.CreateAsync(new ApplicationRole(role));
         }
    }
