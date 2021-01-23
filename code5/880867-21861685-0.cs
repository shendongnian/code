    using (var reader = new StreamReader("c:\\test.txt"))
    {
        string line1 = reader.ReadLine();
        string line2 = reader.ReadLine();
        string line3 = reader.ReadLine();
        // etc..
    }
    
