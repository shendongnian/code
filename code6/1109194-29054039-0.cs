    using (StreamWriter writer = new StreamWriter("c:\\temp\\temp.txt"))
    {
        Console.SetOut(writer);
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("{0}: {1}", DateTime.Now.ToShortTimeString(), i);
        }
    }
