    static bool Seek(Stream stream, long line, long column)
    {
        // Skip the UTF8 header:
        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding(true);
        int preamble = enc.GetPreamble().Length;
        stream.Seek(preamble, SeekOrigin.Begin);
    
        long currentLine = 0;
        long currentColumn = 0;
    
        var newLine = Environment.NewLine;
    
        int newLineChars = 0;
    
        byte[] b = new byte[1];
        while (stream.Read(b, 0, 1) > 0)
        {
            currentColumn++;
            if (currentLine == line - 1 && currentColumn == column - 1)
            {
                return true;
            }
            char c = (char)b[0];
            if (c == newLine[0] || c == newLine[1])
            {
                newLineChars++;
    
                if (newLineChars == newLine.Length)
                {
                    newLineChars = 0;
                    currentColumn = 0;
                    currentLine++;
                    if (currentLine > line)
                    {
                        return false;
                    }
                }
            }
        }
        return false;
    }
