       private static volatile Form2 instance = null;
        private static object lockThis = new object();
        
        private Form2()
        {
            InitializeComponent();
        }
        public static Form2 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(lockThis)
                    {
                        if (instance == null)
                        {
                            instance = new Form2();
                        }
                    }
                }
                return instance;
            }
        }
