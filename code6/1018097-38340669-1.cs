         ConfigureAuth(app);
         GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () =>  new RealTimeNotificationsUserIdProvider());
                app.Map("/signalr", map =>
              {
                  var hubConfiguration = new HubConfiguration
                {            
                EnableDetailedErrors  = true,                
                EnableJavaScriptProxies = false
                 };
                  map.RunSignalR(hubConfiguration);
               });
