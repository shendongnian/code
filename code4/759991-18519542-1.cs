    class MainClass
    {
        ObjectA foo = null;
        OtherClass.InitializeObjectA(out foo);
    }
    
    class OtherClass
    {
        public static void InitializeObjectA(out ObjectA device)
        {
            device = new ObjectA();
        }
    }
