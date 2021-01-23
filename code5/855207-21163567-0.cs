     Keepers.Add(outp);
    
    Keepers.Sort();
    
     newKeepers = Keepers.Distinct().ToList();
    
    foreach (object o in newKeepers)
                {
                    Console.WriteLine(o);
                }
    Console.ReadLine();
