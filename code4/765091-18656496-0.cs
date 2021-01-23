    public void myMethod(Action act)
    {
        act();
    }
    
    myMethod( () => Console.WriteLine("yay") );
