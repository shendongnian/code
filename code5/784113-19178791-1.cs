    static void Main(string[] args)
    {
        ArrayList r = new ArrayList();
        Random ran = new Random();      
        int num = 0;
        for (int i = 0; i < 50; i++)
        {
            do { num = ran.Next(1, 51); } while (r.Contains(num));
            r.Add(num);
        }
        for (int i = 0; i < 50; i++)
           Console.WriteLine(r[i]);
        Console.ReadKey();
    }
