    [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _targetUrl = testContext.Properties["targetUrl"].ToString();           
        }
