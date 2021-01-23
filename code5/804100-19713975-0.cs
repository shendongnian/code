    List<String> Test = new List<String>();
    
    Test.Add("TEST");
    Test.Add("Test");
    
    Console.WriteLine(Test[0]); // TEST
    Console.WriteLine(Test[1]); // Test
    
    char[] t = Test[0].ToCharArray();
