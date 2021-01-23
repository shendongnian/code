    object x = 2;
    List<object> newList = new List<object>();
    newList.Add(x);
    System.Console.WriteLine(x);
    x = 7;
    System.Console.WriteLine(newList[0]);
    newList[0] = 10;
    System.Console.WriteLine(x);
   
