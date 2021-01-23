    namespace BaseLibrary
    {
        [Export("base",typeof(AppSettingsDefaultImpl))]
        class AppSettings : AppSettingsDefaultImpl
            {
                public override string getAppName()
                {
                    return "ABC";
                }
        
            }
    }
    
    namespace ChildApp1
    {
        [Export("child",typeof(AppSettingsDefaultImpl))]
        class AppSettings : AppSettingsDefaultImpl
            {
                public override string getAppName()
                {
                    return "ABC";
                }
        
            }
    }
