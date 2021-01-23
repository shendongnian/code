    public class Config
    {
        public int SomeSetting
        {
            get
            {
                if (HttpContext.Current.Application["SomeSetting"] == null)
                {
                    //this is where you set the default value 
                    HttpContext.Current.Application["SomeSetting"] = 4; 
                }
    
                return Convert.ToInt32(HttpContext.Current.Application["SomeSetting"]);
            }
            set
            {
                //If needed add code that stores this value permanently in XML file or database or some other place
                HttpContext.Current.Application["SomeSetting"] = value;
            }
        }
    
        public DateTime SomeOtherSetting
        {
            get
            {
                if (HttpContext.Current.Application["SomeOtherSetting"] == null)
                {
                    //this is where you set the default value 
                    HttpContext.Current.Application["SomeOtherSetting"] = DateTime.Now;
                }
    
                return Convert.ToDateTime(HttpContext.Current.Application["SomeOtherSetting"]);
            }
            set
            {
                //If needed add code that stores this value permanently in XML file or database or some other place
                HttpContext.Current.Application["SomeOtherSetting"] = value;
            }
        }
    }
