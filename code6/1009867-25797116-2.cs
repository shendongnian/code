    var numbers = new SortedSet<int>();
    numbers.Add(16); numbers.Add(3); numbers.Add(45);
    Console.WriteLine(" {0} {1} {2}", 
        numbers.Max,                           
        numbers.ElementAt(1),// use numbers.Count/2 instead of 1 to determine the middle progr.
        numbers.Min);                         
