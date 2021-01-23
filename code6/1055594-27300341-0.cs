    static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            using (FileStream stream = new FileStream("file.txt", FileMode.OpenOrCreate))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 0x1000, true))
            using (StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false), 0x1000, true))
            {
                Console.WriteLine("Read \"" + reader.ReadToEnd() + "\" from the file.");
            }
        }
        Console.ReadLine();
    }
