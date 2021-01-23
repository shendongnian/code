    using(StreamWriter writer = new StreamWriter(@"C:\File\Test.txt"))
    {
        writer.WriteLine("Fun Times!");
    }
    Console.WriteLine("Finally !");
    Console.ReadLine();
