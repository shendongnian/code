    [NotMapped]
    public List<Module> GrabModulesWithPermission(string permission)
    {
      var toReturn = new List<Module>();
      
      if (this.Children != null && this.Children.Any(c => c.Permissions.Any(r => r.Role == permission))
      {
         toReturn.AddRange(this.Children.Where(c => c.Permissions.Any(r => r.Role == permission).SelectMany(c => c.GrabModulesWithPermission(permission)));
      }
    
      toReturn.Add(this);
    
      return toReturn;
    }
