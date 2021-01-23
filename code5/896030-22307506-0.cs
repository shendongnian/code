    Console.WriteLine("Enter number of jurors, please"); 
    int jury;
    
    if (!int.TryParse(Console.ReadLine(), out jury)) { 
      Console.WriteLine("Incorrect jury number format");
    
      return; // <- I'd exit on the first error occured; you may adopt different policy
    }
    else if ((jury < 1) || (jury > 100000)) {
      Console.WriteLine("Jury should be in range [1..100000]");
    
      return;
    }
    
    var List<int> = new List<int>();
    
    for (int i = 0; i < jury; ++i) {
      int vote;
      Console.WriteLine("Enter next vote, please"); 
    
      if (!int.TryParse(Console.ReadLine(), out vote)) {
        Console.WriteLine("Incorrect vote format");
    
        return;
      }
      else if ((vote < 1) || (vote > 10)) {
        Console.WriteLine("Each vote should be in range [1..10]");
    
        return;
      }
    
      votes.Add(vote);
    } 
