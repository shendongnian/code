    var roleEndpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["SslEndpoint"];
    this.roleProtocol = roleEndpoint.Protocol;
    this.rolePort = roleEndpoint.IPEndpoint.Port.ToString();
    if (!RoleEnvironment.IsEmulated)
    {
          this.roleHostname = "yourexternalhostname.com";
          var appPoolUser = "user";
          var appPoolPass = "password";
          using (var serverManager = new ServerManager())
          {
               string appPoolName = serverManager.Sites[0].Applications.First().ApplicationPoolName;
               var appPool = serverManager.ApplicationPools[appPoolName];
               appPool.ProcessModel.UserName = appPoolUser;
               appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
               appPool.ProcessModel.Password = appPoolPass;
               appPool.AutoStart = true;
               appPool["startMode"] = "AlwaysRunning";
               appPool.ProcessModel.IdleTimeout = TimeSpan.Zero;
               appPool.Recycling.PeriodicRestart.Time = TimeSpan.Zero;
               serverManager.CommitChanges();
           } 
    }
    else
    {
         this.roleHostname = roleEndpoint.IPEndpoint.Address.ToString();
    }
