    static void Main(string[] args)
    {
        int i, pcm, maxm = int.MinValue, minm = int.MaxValue;
        for (i = 1; i <= 3; i++)
        {
            Console.WriteLine("Please enter your computer marks");
            pcm = int.Parse(Console.ReadLine());
            maxm = Math.Max(maxm, pcm);
            minm = Math.Min(minm, pcm);
        }
        Console.ReadKey();
    }
