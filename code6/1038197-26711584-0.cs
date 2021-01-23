    static void Main(string[] args)
    {
        var candidates = new Dictionary<string, int>();
        Console.WriteLine("Enter number of candidates");
        var size = int.Parse(Console.ReadLine());
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Enter a Candidate Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter number of votes thus far");
            var votes = int.Parse(Console.ReadLine());
            candidates.Add(name, votes);
        }
        Console.WriteLine("Average votes: {0}", candidates.Average(entry => entry.Value));
        Console.WriteLine("Min number of votes is: {0}", candidates.Min(entry => entry.Value));
    }
