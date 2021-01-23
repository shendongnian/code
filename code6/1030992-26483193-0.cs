    private static void RunTest()
    {
        for (int i = 0; i < 100; i++)
        {
            var lst = new LinkedList<int>();
    
            Parallel.For(1, 51, j =>
            {
                lst.AddLast(j);
            });
    
            if (lst.Count < 50)
            {
                Console.WriteLine(lst.Count);
            }
        }
    }
