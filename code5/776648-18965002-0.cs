    public string ConvertToBlock(string text, int lineLength)
    {
        string output = "\t";
        
        int currentLineLength = 0;
        for (int index = 0; index < text.Length; index++)
        {
            if (currentLineLength < lineLength)
            {
                output += text[index];
                currentLineLength++;
            }
            else
            {
                if (index != text.Length - 1)
                {
                    if (text[index + 1] != ' ')
                    {
                        int reverse = 0;
                        while (text[index - reverse] != ' ')
                        {
                            output.Remove(index - reverse - 1, 1);
                            reverse++;
                        }
                        index -= reverse;
                        output += "\n\t";
                        currentLineLength = 0;
                    }
                }
            }
        }
        return output;
     }
