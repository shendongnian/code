        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }
        private HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }
    
