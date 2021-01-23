    public class TestFailedException : Exception
    {
        public TestFailedException(string message) : base(message) { }
    }
    void Test()
    {
        try 
        {
            Variable1.Value = 1;
            Variable1.write();
            verifyValue(Variable1, 1);
            //next test steps
            ...
            Console.WriteLine("Test succeeded");
        }
        catch (TestFailedException ex)
        {
            Console.WriteLine("Test failed: " + ex.Message);
        }
    }
    private void verifyValue(TypeOfVariable Var, double Value)
    {
        Var.read();
        if (Var.Value != Value)
        {
            throw new TestFailedException("Actual value: " + Var.Value.ToString()
                + ", expected value: " + Value.ToString());
        }
    }
