     public class AppServiceHost : AppHostBase
        {
            public AppServiceHost()
                : base("Rest Service", typeof (AnyServiceYouHave).Assembly)
            {
                SetConfig(new EndpointHostConfig
                    {
                        //your configuration
                    });
            }
             public override void Configure(Container container)
            {
                //Your configuration
            }
    }
