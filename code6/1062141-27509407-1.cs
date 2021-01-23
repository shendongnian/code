    public static IList<string> ParseCSVLine(string csvLine)
    {
        List<string> result = new List<string>();
        StringBuilder buffer = new StringBuilder();
        bool inQuotes = false;
        char lastChar = '\0';
        foreach (char c in csvLine)
        {
            switch (c)
            {
                case '"':
                    if (inQuotes)
                    {
                        inQuotes = false;
                    }
                    else
                    {
                        if (lastChar == '"')
                        {
                            buffer.Append('"');
                        }
                        inQuotes = true;
                    }
                    break;
                case ',':
                    if (inQuotes)
                    {
                        buffer.Append(',');
                    }
                    else
                    {
                        result.Add(buffer.ToString());
                        buffer.Clear();
                    }
                    break;
                default:
                    buffer.Append(c);
                    break;
            }
            lastChar = c;
        }
        result.Add(buffer.ToString());
        buffer.Clear();
        return result;
    }
