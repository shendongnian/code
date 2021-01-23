    string Test = "This is a test string";
    List<string> parts = new List<string>();
    int i = 0; 
    do
    {
       parts.Add(Test.Substring(i,System.Math.Min(5, Test.Substring(i).Length))); 
       i+= 5;
    } while (i < Test.Length);
