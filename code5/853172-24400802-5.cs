    public void CheckDynamic()
    {
        dynamic test = 10;
        test = test + 10;     // No error
        test = "hello";       // No error, neither compile time nor run time
    }
