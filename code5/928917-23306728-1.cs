    // This does exactly what it looks like.
    long position = GetMyLastReadPosition();
    using (var file = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        if (position == file.Length)
            return;
                
        file.Position = position;
        using (var reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Do reading.
            }
            position = file.Position; // Store this somewhere too.
        }
    }
