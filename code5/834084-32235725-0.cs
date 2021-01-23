    foreach(string loop1 in File.ReadLines("data.txt"))
    {
        Console.WriteLine("loop1: " + loop1);
        foreach(string loop2 in File.ReadLines("data.txt"))
        {
            Console.WriteLine("loop2: " + loop2);
            foreach(string loop3 in File.ReadLines("data.txt"))
            {
                Console.WriteLine("loop3: " + loop3);
            }
        }
    }
