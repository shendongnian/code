    static double ParseOrZero(string input)
    {
        double result;
        double.TryParse(input, out result);
        return result;
    }
