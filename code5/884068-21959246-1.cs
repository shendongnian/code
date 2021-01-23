        public static IGlobalSettings Settings
        {
            get { return _Settings ?? (_Settings = GlobalSettings.Instance); }
        } static IGlobalSettings _Settings;
 	
