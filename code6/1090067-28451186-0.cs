    foreach (var site in sites)
    {
      IISService serv = new IISService();
    
      serv.Name = site.Name;
      serv.State= site.State.ToString();
      serv.PhysicalPath= site.Applications["/"].VirtualDirectories[0].PhysicalPath;
    
      System.Net.IPEndPoint endP = site.Bindings[0].EndPoint;
                                
      string protocol =   site.Bindings[0].Protocol;
    
      allServices.Add(serv);
    }
