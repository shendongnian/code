    public void MustUseReturnValueFN(out int result)
    {
       result = 1;
    }
    
    static void Main()
    {
       int returnValue;
       MustUseReturnValueFN(out returnValue);
       Console.WriteLine(returnValue) // this will print '1' to the console
    }
