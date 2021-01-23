    //(psuedocode)
    private Dictionary<Type, string> RoleMap;
    
    void SomeInitializationCodeThatRunsOnce()
    {
      RoleMap.Add(typeof(Manager), @"\ManagerHome");
      RollMap.Add(typeof(Accountant), @"\AccountantHome");
      // ect...
    }
    
    string GetDestination(Role x)
    {
      string destination;
      if(!RoleMap.TryGet(x.GetType(), out destination))
        destination = @"\Home";
      return destination;
    }
