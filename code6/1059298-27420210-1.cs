    private static void WriteLineIndented(string line, int leftMargin, int width)
    {
        if (string.IsNullOrEmpty(line))
            return;
    
        for(int i = 0; i < leftMargin; i++)
            Console.Write(" ");
    
        if (line.Length <= width - leftMargin)
        {
            Console.WriteLine(line);
            return;
        }
        else
        {
            int position = Math.Min(width - leftMargin, line.Length - 1);
    
            while (position > 0 && line[position] != ' ')
                position--;
    
            Console.WriteLine(line.Substring(0, position));
            WriteLineIndented(line.Substring(position + 1, line.Length - position - 1), leftMargin, width);
        }
    }
