        private static volatile ViewModel instance;
        private static object _mutex = new object();
        private ViewModel() { }
        
        
        private  Model model;        
       
        public  Model NameValue
        {
            get { return model; }
            set { model = value; }
        }        
        
        public static ViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_mutex)
                    {
                        if (instance == null)
                        {
                            instance = new ViewModel();
                            instance.model = new Model();
                        }
                    }
                }
                return instance;
            }
        }
    }`
