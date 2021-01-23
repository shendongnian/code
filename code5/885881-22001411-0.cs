    private static IList<string> betweenQuotes(string input)
    {
        var result = new List<string>();
        int leftQuote = input.IndexOf("\"");
        while (leftQuote > -1)
        {
            int rightQuote = input.IndexOf("\"", leftQuote + 1);
            if (rightQuote > -1 && rightQuote > leftQuote)
            {
                result.Add(input.Substring(leftQuote + 1, (rightQuote - (leftQuote + 1))));
            }
            leftQuote = input.IndexOf("\"", rightQuote + 1);
        }
        return result;
    }
