    public int[] digitArrayFromNumber(int number, int digits)
    {
        return number.ToString()
            .PadLeft(digits, '0')
            .Select(c => int.Parse(c.ToString()))
            .ToArray();
    }
