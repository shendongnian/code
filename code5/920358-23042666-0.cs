     public class MvcBootStrapper
            {
                public static void ConfigurationStructureMap()
                {
                    ObjectFactory.Initialize(x =>
                    {
                        x.AddRegistry<MyService>();
                    });
                }
            }
