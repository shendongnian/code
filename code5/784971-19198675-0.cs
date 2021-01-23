     int i, pcm, maxm = 0, minm = 0;
        for (i = 1; i <= 3; i++)
        {
            if (pcm > maxm)
            {
               maxm = pcm;
            }
            if (pcm < minm)
            {
               minm = pcm;
            }
            Console.WriteLine("Please enter your computer marks");
            pcm = int.Parse(Console.ReadLine());
        }
        Console.ReadKey();
    }
