    interface ClassType
    {
        void DoSomething();
    }
    class A : ClassType
    {
        void DoSomething()
        {
            //some code
        }
    }
    class B : ClassType
    {
        void DoSomething()
        {
            //some code
        }
    }
    class Main
    {
        public static void main()
        {
            A objectA = new A();
            B objectB = new B();
            ClassType objectC;
            objectC = objectA;
            objectC.DoSomething();
            objectC = objectB;
            objectC.DoSomething();
        }
    }
