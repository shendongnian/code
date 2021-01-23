    double x = 100000000000.0;
    x*= 0.00000000001;
    Console.WriteLine(x); // Prints "1"
    bool y = ((double)x == 1.0);
    Console.WriteLine(y); // Prints "False"
