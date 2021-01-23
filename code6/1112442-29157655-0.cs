    // myproject.interfaces.dll
    interface IA 
    {
        void Process(IB b);
    }
    interface IB
    {
        void Process(IA a);
    }
    // myproject.A.dll - depends on myproject.interfaces.dll
    class A : IA
    {
        ....
    }
