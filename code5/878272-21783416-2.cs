    if(args.Length>0)
    {
        int tala = Convert.ToInt32(args[0]);
        MultiplicationTable test = new MultiplicationTable(tala);
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("No Command Line Arguments - Quiting");
    }
