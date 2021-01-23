        private static readonly object mylock = new object();
        public static Dll Instance
        {
            get {
               if(_INSTANCE == null) {
                   lock(mylock) {
                      if(_INSTANCE == null) 
                          _INSTANCE = new Dll();
                   }
               }
               return _INSTANCE;
            }
        }
