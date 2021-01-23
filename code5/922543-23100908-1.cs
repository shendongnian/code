    Console.WriteLine ("Please enter the number of traps.");
    Random rnd = new Random ();
    int traps;
    traps = Convert.ToInt32 (Console.ReadLine ());
    Console.WriteLine ("X coordinates for the traps", traps);
    for (int X = 1; X <= traps; X++) 
    {
        int rx = rnd.Next (1, 11);
        Console.Write ("{0}", rx); 
        Console.WriteLine ();
    }
    Console.WriteLine ("Y coordinates for the traps");
    for (int Y = 1; Y <= traps; Y++) 
    {
        int ry = rnd.Next (1, 11);
        Console.Write ("{0}", ry); 
        Console.WriteLine ();
    }
