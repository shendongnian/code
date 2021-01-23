    public override void Configure(Funq.Container container)
    {
        SetConfig(new HostConfig { 
            DebugMode = true,
            DefaultContentType = "application/xml"
        });
    }
