    static void Main(string[] args)
    {
        int i, pcm = 0, maxm = 0;
        for (i = 1; i <= 3; i++)
        {
            Console.WriteLine("Please enter your computer marks");
            pcm = int.Parse(Console.ReadLine());
            
            // logic to save off the larger of the two (maxm or pcm)
            maxm = maxm > pcm ? maxm : pcm;
        }
        Console.WriteLine(string.Format("The max value is: {0}", maxm));
        Console.ReadKey();
    }
