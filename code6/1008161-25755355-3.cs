    static void Main(string[] args)
    {
        // look in the first argument for a number of elves
        int nElves = 0;
        List<Elf> e = new List<Elf>();
        if (args.Length > 0 && Int32.TryParse(args[0], out nElves))
        {
            for (int i = 0; i < nElves; i++)
            {
                e.Add(new Elf());
            }
        }
        else
            Console.WriteLine("The first argument to this program must be the number of elves!");
    }
