    private static void ShowProfileServices(INetFwProfile prof)
    {
      var services = prof.Services.Cast<INetFwService>();
      var sharing = services.FirstOrDefault(sc => sc.Name == "File and Printer Sharing");
      if (sharing != null)
        Console.WriteLine(sharing.Name + " Enabled : " + sharing.Enabled.ToString());
      else
        Console.WriteLine("No sharing service !");
    
      var discovery = services.FirstOrDefault(sc => sc.Name == "Network Discovery");
    
      if (discovery != null)
        Console.WriteLine(discovery.Name + " Enabled : " + discovery.Enabled.ToString());
      else
        Console.WriteLine("No network discovery service !");
    
      var remoteDesktop = services.FirstOrDefault(sc => sc.Name == "Remote Desktop");
      if (remoteDesktop != null)
        Console.WriteLine(remoteDesktop.Name + " Enabled : " + remoteDesktop.Enabled.ToString());
      else
        Console.WriteLine("No remote desktop service !");
    }
