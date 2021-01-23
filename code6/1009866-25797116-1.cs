    var numbers = new SortedSet<int>();
    numbers.Add(16); numbers.Add(3); numbers.Add(45);
    Console.WriteLine(" {0} {1} {2}", 
        numbers.Max,                           
        numbers.ElementAt(1), // use Count/2 to determine middle progr.
        numbers.Min);                         
