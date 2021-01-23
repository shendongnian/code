    public static IEnumerable<string> GenerateItems()
    {
        var buffer = new[] { '@' };
        var maxIdx = 0;
        while(true)
        {
            var i = maxIdx;
            while (true)
            {
                if (buffer[i] < 'Z')
                {
                    buffer[i]++;
                    break;
                }
                if (i == 0)
                {
                    buffer = Enumerable.Range(0, ++maxIdx + 1).Select(c => 'A').ToArray();
                    break;
                }
                    
                buffer[i] = 'A';
                i--;
            }
            yield return new string(buffer);
        }
        // ReSharper disable once FunctionNeverReturns
    }
