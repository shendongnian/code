    int a = 0, b = 0;
    void DoSomething(ref int a, ref int b) {
        a = 1;
        b = 2;
    }
    Console.WriteLine(a); // Prints 1
    Console.WriteLine(b); // Prints 2
