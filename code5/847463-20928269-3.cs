    public static string NextImageName(string filename, int newNumber)
    {
        if (newNumber == 0)
        {
            return Regex.Replace(filename, @"[\d+]", newNumber.ToString());
        }
        if (newNumber > 9)
        {
            return Regex.Replace(filename, @"(\d+)(?!.*\d)", newNumber.ToString());
        }
        if (newNumber < 10)
        {
            return Regex.Replace(filename, @"(\d)(?!.*\d)", newNumber.ToString());
        }
        return filename;
    }
