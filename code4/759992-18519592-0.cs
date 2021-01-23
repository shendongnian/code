    class MainClass
    {
        ObjectA foo = OtherClass.InitializeObjectA();
    }
    
    class OtherClass
    {
        public static ObjectA InitializeObjectA()
        {
            return new ObjectA();
        }
    }
