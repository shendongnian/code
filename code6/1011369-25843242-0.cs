    private static IEnumerable<string> ReadLines(StreamReader stream)
    {
        StringBuilder sb = new StringBuilder();
    
        int symbol = stream.Peek();
        while (symbol != -1)
        {
            symbol = stream.Read();
            if (symbol == 13 && stream.Peek() == 10)
            {
                stream.Read();
                string line = sb.ToString();
                sb.Clear();
                yield return line;
            }
            else
                sb.Append((char)symbol);
        }
    
        yield return sb.ToString();
    }
