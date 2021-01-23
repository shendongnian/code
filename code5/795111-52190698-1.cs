    class BMainClass
    {
        void Method()
        {
            BChildClass cc = new BChildClass();
            BOtherChild oc = new BOtherChild( );
            oc.m_SharedChildClassInfo = cc;
            //Set the name property of childclass
            cc.name = "some name";  // only this instance of BChildClass will have this name, but it visible in BOtherChild
        }
    }
    class BChildClass
    {
        public string name {get; set;}
    }
    class BOtherChild
    {
        public BChildClass m_SharedChildClassInfo;
    
        void Method()
        {
            BChildClass cc = m_SharedChildClassInfo; 
            // cc will have the same name as the cc in MainClass
            // in fact it is the exact same instance as declared in MainClass so evetythng is the same
        }
    }
