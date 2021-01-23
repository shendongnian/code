    public static IEnumerable<TestB> GetTestBs()
    {
    	for (int i = 0; i < 2; i++)
    	{
    		var b = new TestB();
    		b.A = "A";
    		b.B = "B";
    		b.C = TestB.GetCs();
    
    		yield return b;
    	}
    }
