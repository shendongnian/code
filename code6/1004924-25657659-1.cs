      //Create a class and static function to get the context
        public class DaatabaseFramework
        {
            public static SiteModelContainer GetContext()
            {
                return new SiteModelContainer();
            }
        }
    
      //Use the below to use the context
        using (var context=DaatabaseFramework.GetContext())
        {
                    
        }
