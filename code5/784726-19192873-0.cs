    static void Main(string[] args)
    {
        int i, pcm, maxm = 0;
        List<int> vals = new List<int>();
        for (i = 1; i <= 3; i++)
        {
        Console.WriteLine("Please enter your computer marks");
        pcm = int.Parse(Console.ReadLine());
        vals.Add(pcm);
        }
        maxm = vals.Max(a => a);
        Console.ReadKey();
    }
