    public static class GlobalSettings
    {
        // TODO add public static get properties for various settings
        private static int s_nSomeAppInt;
    
        public static void Init ( ISettingReader oReader )
        {
            // TODO use reader to read individual setting values
    
            int nSomeAppInt = oReader.ReadSomeAppInt ();
            // TODO validate nSomeAppInt and store it in private
            // static field
            s_nSomeAppInt = nSomeAppInt;
        }
        public static int SomeAppInt
        {
            get
            {
                return ( s_nSomeAppInt );
            }
        }
    }
