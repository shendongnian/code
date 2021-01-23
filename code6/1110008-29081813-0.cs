    string line;
    using (StreamReader reader = new StreamReader("C:\\temp\\test-1.txt"))
    {
        while (reader.Peek() > -1)
        {
            line = reader.ReadLine();
            foreach (char c in line)
            {
                Console.WriteLine(c);
            }
        }
    }
