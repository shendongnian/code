    public class Startup {
    
       public static IUnityContainer Container; //Static field for hold ioc container reference.
    
    
        public void Configuration(IAppBuilder app)
                {
                    //Code Omitted for brevity
        
                    Container = YourIoCContainerReference:
                }
        }
    }
