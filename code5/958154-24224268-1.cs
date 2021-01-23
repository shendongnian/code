    class ImgSigDbConfig : DbConfiguration
    {
        public ImgSigDbConfig()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
