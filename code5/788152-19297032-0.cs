    public class Config
    {
        public static ClientConfiguration Current
        {
            get
            {
                if (HttpContext.Current.Application["clientconfig"] == null)
                { 
                    //Fill object from database
                }
    
                return HttpContext.Current.Application["clientconfig"] as ClientConfiguration;
            }
    
            set
            { 
                //store object in database 
    
                //invalidate what is stored in application object 
                //so that it will be refreshed next time it's used
                HttpContext.Current.Application["clientconfig"] = null;
            }
        }
    }
