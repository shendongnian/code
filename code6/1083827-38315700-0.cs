    [Application]
    public class AppInitializer : Application
    {
		private static Context _appContext;
		
		public MobileServiceClient ServiceClient { get; set; }
		
		public override void OnCreate()
        {
            base.OnCreate();
			
			ServiceClient = new MobileServiceClient("http://<your url>.azure-mobile.net/", "< you key>")
            {
                SerializerSettings = new MobileServiceJsonSerializerSettings()
                {
                    CamelCasePropertyNames = true
                }
            };
		}
		
		public static Context GetContext()
        {
            return _appContext;
        }
	}
