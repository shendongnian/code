    void Main()
    {
      string test = "text some more text";
      
      string result = test.Substring(0,test.IndexOf(" "));
      
      // prints "text"
      Console.WriteLine(result);
    }
