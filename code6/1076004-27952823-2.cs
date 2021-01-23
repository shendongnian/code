    using (var reader = new StreamReader(stream))
    {
        for(string line = reader.ReadLine();
            reader.EndOfFile == false;
            line = reader.ReadLine())
        {
            //...
        }
    }
