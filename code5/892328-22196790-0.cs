    class A
    {
        static SomeClass aField;
    
        static SomeClass aProperty
        {
            get
            {
               if (aField == null) { aField = new Someclass("asfae"); }
               return aField;
            }
        }
    }
