    struct stuctName
    {
          public char dataMemberOne;
          public char dataMemberTwo;
    }
    static void Main()
    {
        structName structOne = new structName();
        structName structTwo = new structName();
    
        structOne.dataMemberOne = 'a'; //aassign a value
    
        Console.WriteLine(structOne.dataMemberOne);  // will output 'a'
    
        return 0;
    }
