    HashSet<int> hs = new HashSet<int>();
    int[] Arr = { 9, 5, 6, 3, 8, 2, 5, 1, 7, 4 };
    
    foreach (item in Arr) 
      if (hs.Contains(item)) {
        Console.WriteLine("duclicate found");
        // break; // <- uncomment this if you want one message only
      }
      else 
        hs.Add(item);
