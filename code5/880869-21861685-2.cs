    using (var reader = new StreamReader("c:\\test.txt"))
    {
        while (some_condition)
        {
            string line = reader.ReadLine();
            // Do something
        }
    }
    
