    static void Main(string[] args)
    {
        int i, pcm, maxm = 0;
        for (i = 1; i <= 3; i++)
        {
            Console.WriteLine("Please enter your computer marks");
            pcm = int.Parse(Console.ReadLine());
            if(maxm <= pcm)
            {
                 maxm = pcm;
            }
        }
        Console.ReadKey();
    }
