    public static List<string> GetVariables(string formula)
    {
        if (string.IsNullOrWhitespace(formula)) return new List<string>();
        var operators = new List<char> { '+', '-', '*', '/', '^', '%', '(', ')' };
            
        int temp;
        return formula
            .Split(operators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Where(operand => !int.TryParse(operand[0].ToString(), out temp))
            .ToList();
    }
