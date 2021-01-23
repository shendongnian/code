    using (var fs = new FileStream(@"path_to_your_file\Registered.txt", FileMode.Open))
    {
        using (var reader = new StreamReader(fs))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                // do your checks here
                line = reader.ReadLine();  
            }
        }
    }
