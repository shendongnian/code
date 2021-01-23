    List<String> Test = new List<String>();
    
    Test.Add("TEST");
    Test.Add("Test");
    
    string arry = Test.Where(x => x[0] == 'T').ToArray()[0];
    
    Console.WriteLine(arry);
