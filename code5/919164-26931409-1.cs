            HostFactory.Run(x =>
            {
                x.Service<MyService>((s) =>
                {
                    var serviceName = s.ServiceName;
                    return new MyService();
                });
             }
    /***************************/
    class MyService : ServiceControl
    {
        public bool Start(HostControl hostControl) {  }
        public bool Stop(HostControl hostControl)  {  }
    }
