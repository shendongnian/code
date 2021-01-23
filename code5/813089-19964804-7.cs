    private static void myFunction1() { Console.WriteLine("Hello!"); }
    private static void myFunction2() { Console.WriteLine("Bye!"); }
    private static void myFunction0() { return; }
    ... // in some function, i.e. Main()
    Action myDelegate = null;
    myDelegate = new Action( myFunction1 );
    myDelegate(); // writes "Hello!"
    myDelegate = new Action( myFunction2 );
    myDelegate(); // writes "Bye!"
    myDelegate = new Action( myFunction3 );
    myDelegate(); // does "nothing"
