    StreamReader input = new StreamReader(@"c:\c#\inp.txt");
    while (!input.EndOfStream)
    {
        string text = input.ReadLine();
        string[] bits = text.Split(',');
        for (int i = 0; i < 8; i++)
        {
            int x = int.Parse(bits[i]);
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
