    void Main()
    {
    	TestMethod();
    }
    
    public void TestMethod(params string[] args)
    {
    	Console.WriteLine("NonGeneric");
    }
    
    public void TestMethod(params List<string>[] args)
    {
    	Console.WriteLine("Generic");
    }
