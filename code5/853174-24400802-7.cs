    public void CheckVar()
    {
        var test = 10;         // after this line test has become of integer type
        test = test + 10;      // No error
        test = "hello";        // Compile time error as test is an integer type
    }
