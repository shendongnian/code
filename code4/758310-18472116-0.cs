    char[] delimiters = new [] { ':' };
    
    foreach (string line in File.ReadAllLines(@"some path"))
    {
        if (!string.IsNullOrWhiteSpace(line))
        {
            string[] parts = line.Split(delimiters);
            
            if (parts != null && parts.Length == 2)
            {
                string label = parts[0];
                string value = parts[1];
    
                Console.WriteLine("Label: {0}, Value: {1}", label, value);
            }
        }
    }
