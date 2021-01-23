        public Reddit() : this(new WebAgent())
        {
            
        }
        public Reddit(IWebAgent agent)
        {
            JsonSerializerSettings = new JsonSerializerSettings();
            JsonSerializerSettings.CheckAdditionalContent = false;
            JsonSerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
            _webAgent = agent;
            CaptchaSolver = new ConsoleCaptchaSolver();
        }
