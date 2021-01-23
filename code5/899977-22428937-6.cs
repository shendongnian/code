    static int len = 1;
    static void Main()
    {
        var len = 3.14; // OK, can hide field
        Console.WriteLine(len); // OK, 'len' refers to local variable
        Console.WriteLine(Program.len); // OK, hidden field can still be accessed, with proper qualification
    }
