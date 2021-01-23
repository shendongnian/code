    // this one example shows both 
    //  a set of data shared across all instances of two class
    //  and a set of data sharted between 2 specific classes
    class CMainClass
    {
        void Method()
        {
            CSharedBetweenSome sharedSomeInstances = new CSharedBetweenSome();
            CChildClass cc = new CChildClass(sharedSomeInstances);
            COtherChild oc = new COtherChild(sharedSomeInstances);
            //Set the name property of childclass
            cc.sharedAllValue = "same name for everyone";  // ALL  instance of ChildClass will have this name, ALL instances BOtherChild will be able to acess it
            sharedSomeInstances.name = "sane name for cc and oc instances";
        }
    }
    // Interface - sometimes to make things clean / standard between different classes defining an interface is useful
    interface ICShareInfoAll
    {
        string sharedAllValue { get; set; }
    }
    class CSharedInto : ICShareInfoAll
    {
        // Singletone pattern - still an instance, rather than a static, but only ever one of them, only created first time needed
        private static CSharedInto s_instance;
        public static CSharedInto Instance
        {
            get
            {
                if( s_instance == null )
                {
                    s_instance = new CSharedInto();
                }
                return s_instance;
            }
            private set // singleton  never set only created first use of get
            {
                //s_instance = value;
            }
        }
        // variables shared with every instance of every type of child class
        public string sharedAllValue { get; set; }
    }
    // One child class using  jointly shared and shared with all
    class CChildClass :  ICShareInfoAll
    {
        private CSharedBetweenSome sharedSomeInstance;
        public CChildClass(CSharedBetweenSome sharedSomeInstance)
        {
            this.sharedSomeInstance = sharedSomeInstance;
        }
        // Shared with all 
        public string sharedAllValue {
            get { return CSharedInto.Instance.sharedAllValue;  }           
            set { CSharedInto.Instance.sharedAllValue = value; }
            }
        // Shared with one other
        public string sharedAnotherInstanceValue {
            get { return sharedSomeInstance.name;  }           
            set { sharedSomeInstance.name = value; }
            }
    }
    class COtherChild :  ICShareInfoAll
    {
        private CSharedBetweenSome sharedSomeInstance;
        public COtherChild(CSharedBetweenSome sharedSomeInstance)
        {
            this.sharedSomeInstance = sharedSomeInstance;
        }
        public string sharedAllValue {
            get { return CSharedInto.Instance.sharedAllValue;  }           
            set { CSharedInto.Instance.sharedAllValue = value; }
            }
    
        void Method()
        {
            string val = sharedAllValue;  // shared across instances of 2 different types of class
            string val2 = sharedSomeInstance.name;  // currenlty shared across spefic instances 
        }
    }
