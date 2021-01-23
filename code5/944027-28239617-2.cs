    HostFactory.Run(conf =>
    {
        conf.Service<YourService>(svcConf =>
        {
            svcConf.WhenStarted((service, hostControl) =>
            {
                return service.Start(hostControl);
            }
        }
    }
