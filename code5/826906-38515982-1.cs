    #if Test
      public EndpointAddress address = new EndpointAddress("http://localhost/xxx/Service1.svc");
    #else
      public EndpointAddress address = new EndpointAddress("http://xxx.azurewebsites.net/Service1.svc");
    #endif
      public void Select(Action<CdaServiceManager.CdaService.DatabaseTable> callback, CdaServiceManager.CdaService.DatabaseTable thisTable)
      {
         using (CdaService.Service1Client webService = new CdaService.Service1Client("WSHttpBinding_IService1", address))
         {
             var item = webService.Select(thisTable);
             callback(item);
         }
      }    
