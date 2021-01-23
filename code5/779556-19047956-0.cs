    string path;
    if(args.Length > 0)
    {
      path = args[0];
      Console.WriteLine("Using path: " + path);
    }
    else
    {
       Console.WriteLine("Which folder do you wish to scan?");
       path = Console.ReadLine();
    }
