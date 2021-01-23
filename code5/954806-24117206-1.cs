    interface IMyInterface
    {
        string VALUE{get;set;}
    }
    class A : IMyInterface
    {
       public int Aprop{get;set;}
       public string VALUE{get;set;}
    }
    class B : IMyInterface
    {
       public int Bprop{get;set;}
       public string VALUE{get;set;}
    }
