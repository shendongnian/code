    public void Configuration(IAppBuilder app)
            {
                var config = new HubConfiguration();
                config.EnableJSONP = true;
                app.MapSignalR(config);
            }
