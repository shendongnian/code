    void Main()
    {
    	TestParse("1");
    	TestParse("a");
    	TestParse("1234");
    	TestParse("1a");
    }
    
    void TestParse(string text)
    {
      int result;
      if (int.TryParse(text, out result))
      {
        Console.WriteLine(text + " is a number");
      }
      else
      {
        Console.WriteLine(text + " is not a number");
      }
    }
