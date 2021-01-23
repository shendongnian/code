    public class CoolObject
    {
        public CoolObject(Dictionary<long, bool> objectSettings){
             ObjectSettings = objectSettings;
             //.. do stuff//
        }
        public Dictionary<long,bool> ObjectSettings
        {
            get
            {
                // return Dictionary of settings, but not allow users to modify _objectSettings
            }
            private set
            {
                // enforce new setting obey's some rules
            }
        }
    }
