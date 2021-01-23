    var line = "2014-01-23 09:13:45|\"10002112|TR0859657|25-DEC-2013>0000000000000001\"|10002112";
    var data = GetPartsFromLine(line).ToList();
    private static IEnumerable<string> GetPartsFromLine(string line)
    {
        int position = -1;
        while (position < line.Length)
        {
            position++;
            if (line[position] == '"')
            {
                //go find the next "
                int endQuote = line.IndexOf('"', position + 1);
                yield return line.Substring(position + 1, endQuote - position - 1);
                position = endQuote;
                if (position < line.Length && line[position + 1] == '|')
                {
                    position++;
                }
            }
            else
            {
                //go find the next |
                int pipe = line.IndexOf('|', position + 1);
                if (pipe == -1)
                {
                    //hit the end of the line
                    yield return line.Substring(position);
                    position = line.Length;
                }
                else
                {
                    yield return line.Substring(position, pipe - position);
                    position = pipe;
                }
            }
        }
    }
