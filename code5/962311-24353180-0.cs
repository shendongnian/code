    public static void ExecuteTestMethodDelegate(TestDelegate<string> aTestMethod)
    {
       string message;
       bool result = aTestMethod(out message);
    }
