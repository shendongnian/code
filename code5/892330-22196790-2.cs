    class A
    {
        static SomeClass aField;
        static object aFieldLock = new object();
    
        static SomeClass aProperty
        {
            get
            {
               lock (aFieldLock)
               {
                   if (aField == null) { aField = new Someclass("asfae"); }
                   return aField;
               }
            }
        }
    }
