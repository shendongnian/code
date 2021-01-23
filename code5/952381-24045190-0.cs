    var list = new List<Action>();
    for (var i = 0; i < 7; i++)
    {
      list.Add(() => Console.WriteLine(i));
    }
    list.ForEach(a => a()); // prints "7" 7 times, because `i` was captured inside the loop
