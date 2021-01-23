    // ... information shared across all instances of a class
    // Class A  a1,a2;    a1,a2  share exact same values for certain members
    class MainClass
    {
         void Method()
        {
             ChildClass cc = new ChildClass();
             OtherChild oc = new OtherChild();
             //Set the name property of childclass
             ChildClass.s_name = "some name"; // obviously a shared static because using ChildClass.members not cc.member
             cc.Name = "some name";  // now all instances of ChildClass will have this name
        }
    }
    class ChildClass
    {
        // *** NOTE  'static' keyword ***
        public static string s_name;   // externally refered to by ChildClass.s_name
   
        // this property hides that s_name is a static which is good or bad depending on your feelings about hiding the nature of data
        public string Name           
        {
            get
            {
                return s_name;
            }
            set // singleton so never set only created first use of get
            {
                s_name = value;
            }
        }
    }
    class OtherChild
    {
        public OtherChild()
        {
        }
        void Method()
        {
            ChildClass cc = new ChildClass();
            string str = cc.Name;
            // cc will have the same name as the cc in MainClass
        }
    }
