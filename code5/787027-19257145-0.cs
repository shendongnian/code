    public void Foo(int[] x)
    {
        // The effect of this line is visible to the caller
        x[0] = 10;
        // This line is pointless
        x = new int[] { 20 };
    }
    ...
    int[] original = new int[10];
    Foo(original);
    Console.WriteLine(original[0]); // Prints 10
