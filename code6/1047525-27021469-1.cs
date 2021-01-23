    public App()
            {
                Startup += ApplicationStartup;
    }
    private void ApplicationStartup(object sender, StartupEventArgs e)
            {
                    if (e.InitParams.ContainsKey("k1"))
                    {
                        var key1Value = e.InitParams["k1"];
                    }
                }
    		}
