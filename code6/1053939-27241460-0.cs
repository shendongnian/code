    string[] Tail(string file, int maxLinesToReturn, Encoding encoding)
    {
        Queue<string> mostRecentLines = new Queue<string>();
        foreach (string line in File.ReadLines(file, encoding))
        {
            if (mostRecentLines.Count >= maxLinesToReturn)
            {
                mostRecentLines.Dequeue();
            }
            mostRecentLines.Enqueue(line);
        }
        return mostRecentLines.ToArray();
    }
