     using (ServerManager server = new ServerManager()) 
     {
         var siteConfig = server.Sites.First().GetWebConfiguration();
         var section = siteConfig.GetSection("system.serviceModel/client/endpoint");
         section.SetAttributeValue("address", "net.tcp://192.168.0.1:123/MyService.svc");
         server.CommitChanges();
      }
