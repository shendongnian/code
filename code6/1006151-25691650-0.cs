    public static IEnumerable<string> SkipLines(string file, string line, int count)
    {
        var enumerable = File.ReadLines(file);
        while (enumerable.MoveNext())
        {
            var currentLine = enumerable.Current;
            if (currentLine == line)
            {
                var currentCount = 0;
                while(enumerable.MoveNext() && currentCount < count) 
                {
                      currentCount += 1;
                }
            }
            
            yield return currentLine;
        }
    }
