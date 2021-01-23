    // Keeps most recent 100–200 lines.
    List<string> cache = new List<string>();
    while (true)
    {
        // Create new writer, overwriting old file (if it already exists).
        using (var streamWriter = new StreamWriter(/* ... */))
        {
            // Write last 100 lines from cache.
            if (cache.Count > 0)
                streamWriter.WriteLine(string.Join(Environment.NewLine, cache));
            // Get next line and write it.
            string line = /* your implementation */
            streamWriter.WriteLine(line);
            // Append to cache.
            cache.Add(line);
            // If cache limit reached, we need to recycle.
            if (cache.Count == 200)
            {
                // Keep only most recent 100 lines.
                cache = cache.Skip(100).ToList();
                // Start a new iteration, causing the file to be overwritten.
                continue;
            }
        }
    }
