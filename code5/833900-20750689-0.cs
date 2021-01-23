    void Main()
    {
        string input = "this\ris\non\ra\nsingle\rline\r\nThis is on the next line";
        string output = ReplaceLoneLineBreaks(input);
    
        output.Dump();
    }
    
    public static string ReplaceLoneLineBreaks(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
    
        var result = new StringBuilder();
    
        int index = 0;
        while (index < input.Length)
        {
            switch (input[index])
            {
                case '\n':
                    if (index == input.Length - 1 || input[index+1] != '\r')
                    {
                        result.Append(' ');
                        index++;
                    }
                    else
                    {
                        result.Append(input[index]);
                        result.Append(input[index + 1]);
                        index += 2;
                    }
                    break;
    
                case '\r':
                    if (index == input.Length - 1 || input[index+1] != '\n')
                    {
                        result.Append(' ');
                        index++;
                    }
                    else
                    {
                        result.Append(input[index]);
                        result.Append(input[index + 1]);
                        index += 2;
                    }
                    break;
    
                default:
                    result.Append(input[index]);
                    index++;
                    break;
            }
        }
        return result.ToString();
    }
