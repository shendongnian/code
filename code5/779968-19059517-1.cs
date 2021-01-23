    public bool Test(string input, string[] possibleValues)
    {
        String pattern = GeneratePattern(possibleValues);
        bool result = Regex.IsMatch(input, pattern);
        if (!result)
            {
                Console.WriteLine("Value does not satisfies the condition.");
            }
        else
        {
            Console.WriteLine("Value satisfies the condition.");
        }
        return result;
    }
    private string GeneratePattern(string[] possibleValues)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("^");
        foreach (var possibleValue in possibleValues)
        {
            sb.Append("[");
            sb.Append(possibleValue);
            sb.Append("]");
        }
        sb.Append("$");
        return sb.ToString();
    }
