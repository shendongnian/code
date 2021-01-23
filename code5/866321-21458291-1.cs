    ...
    
    n = Int32.Parse(Console.ReadLine());
    
    // Initial array filled with 1..n values
    int[] data = Enumerable.Range(1, n).ToArray(); 
    // data array indice to show, initially 0..n-1
    List<int> indice = Enumerable.Range(0, n - 1).ToList(); 
    
    Random gen = new Random();
    
    for (int i = 0; i < n; ++i) {
      if (i != 0)
        Console.Write(' ');
    
      index = gen.Next(indice.Count);
    
      Console.Write(data[indice[index]]);
      // Index has been shown, let's remove it since we're not going to show it again 
      indice.RemoveAt(index);
    }    
    
    ...
