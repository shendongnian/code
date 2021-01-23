        protected void Application_Start()
        {
            //....
            YourCustomConfig config = InitializeConfig();
            ActionMethodsRegistrator.RegisterActionMethods(config);
        }
