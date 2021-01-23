    class DisplayNameLanguage : DisplayNameAttribute
    {
        private readonly string resourceName;
        public DisplayNameLanguage(string resourceName)
            : base()
        {
            this.resourceName = resourceName;
        }
    
        public override string DisplayName
        {
            get
            {
                return getDescriptionForLanguage(resourceName);
            }
         }
    }
