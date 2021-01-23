    void SomeFunction()
    {
        var foo = new SomeTypeThatTakesUp1GBOfRam();
    
        DoSomthingWithFoo(foo);
         
        for(int i = 0; i < 10000; i++)
        {
            Thread.Sleep(1000);
        }
    }
