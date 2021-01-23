    static void ReadFile(string fileName)
    {
        using (TextReader reader = new StreamReader(fileName))
        {
            string line = reader.ReadLine();
            Console.WriteLine(line);
            reader.Close();
        }
    }
