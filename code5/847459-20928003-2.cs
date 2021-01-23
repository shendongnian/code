    public static string NextImageName(string filename, int newNumber)
    {
        // ToString("D2") forces the 1-9 range to be passed as 0X no need to test 
        return ReplaceOnce(filename, newNumber.ToString("D2"), (filename.Length - 2));
    }
