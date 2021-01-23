    public class BaseClass
    {
        private string _name;
        private DateTime _login;
    
        public string Name
        {
            get
            {
                return Instance._name;
            }
            set
            {
                _name = value;
            }
        }
        public DateTime Login 
        {
            get
            {
                return Instance._login;
            }
            set
            {
                _login = value;
            }
        }
    
        public static BaseClass Instance
        {
            get 
            {
                // check if null, return a new instance  if null etc...
                return HttpContext.Current.Cache["BaseClassInstance"] as BaseClass;                
            }
            set
            {
                HttpContext.Current.Cache.Insert("BaseClassInstance", value);
            }
        }
    }
    
    public class ChildA : BaseClass
    {
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
    }
    
    public class childB : BaseClass
    {
        public string StreetAdrees { get; set; }
    }
