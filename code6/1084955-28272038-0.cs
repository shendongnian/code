    var sites = new ServerManager().Sites;
    foreach (var site in sites) 
    {
       Console.WriteLine(site.ApplicationDefaults.ApplicationPoolName);
        foreach (var application in site.Applications)
        {
           Console.WriteLine(application.ApplicationPoolName);
        }
    }
   
