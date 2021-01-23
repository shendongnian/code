    MyInteger x = new MyInteger(2);
    List<MyInteger> newList = new List<MyInteger>();
    newList.Add(x);
    Console.WriteLine(x.Value);
    x.Value = 7;
    Console.WriteLine(newList[0].Value);
    newList[0].Value = 10;
    Console.WriteLine(x.Value);
    class MyInteger
    {
      public MyInteger(int value)
      {
            Value = value;
      }
      public int Value { get; set; }
    }
    
