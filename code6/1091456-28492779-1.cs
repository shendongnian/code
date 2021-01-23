    using (StreamReader reader = new StreamReader(stream))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine("Received: " + line);
        }
    }
