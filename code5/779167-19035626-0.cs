    Test a = new Test("Original");
    ChangeMe(ref a);
    Conosole.WriteLine(a.TestString); // Changed
    ...
    static void ChangeMe(ref Test b)
    {
        b = new Test("Changed"); // This will change the value of a!
    }
