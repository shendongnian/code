    public void Call(dynamic arg1, dynamic arg2)
    {
        B b = new B();
        b.DoSomething(arg1); // determine which overload to use based on T1
        b.DoSomething(arg2); // and T2
    } 
