        private static readonly object mylock = new object();
        public static Dll Instance
        {
            get {
               if(INSTANCE == null) {
                   lock(mylock) {
                      if(INSTANCE == null) 
                          _INSTANCE = new Dll();
                   }
               }
               return INSTANCE;
            }
        }
