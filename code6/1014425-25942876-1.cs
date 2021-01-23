    using Microsoft.SqlServer.Management.Smo;
    
  
     void Detach()
     {
          Server smoServer = new Server("MSSQLSERVER2008");
          smoServer.DetachDatabase("HARMDATABASE", False);
     }
