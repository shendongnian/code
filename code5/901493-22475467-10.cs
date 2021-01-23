    IEnumerable<IEnumerable<string>> ReadFileInChunks(
            string fileName,
            char[] separators,
            int chunkSize)
    {
        string[] bucket = null;
        var count = 0;
        foreach(var item in SplitFile(fileName, sperators))
        {
            if (bucket == null)
            {
                bucket = new string[chunkSize]
            }
            bucket[count++] = item;
            if (count != size)
            {
                continue;
            }
            yield return bucket;
            bucket = null;
            count = 0;
        }
        // Alternatively, throw an exception if bucket != null
        if (bucket != null)
        {           
            yield return bucket.Take(count); 
        }
    }
    private IEnumerable<string> SplitFile(
            string FileName,
            char[] separators)
    {
        var check = new HashSet<int>(seperators.Select(c => (int)c);
        var buffer = new StringBuilder();
        using (var reader = new StreamReader(FileName))
        {
            var next = reader.Read();
            while(next != -1)
            {
                if (check.Contains(next))
                {
                    yield return buffer.ToString();
                    buffer.Clear();
                    continue;
                }
                buffer.Append((char)next);
                next = reader.Read();
            }   
        }
        if (buffer.Length > 0)
        {
            yield return buffer.ToString();
        }
    }
