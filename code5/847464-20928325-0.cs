    void Main()
    {
        NextImageName("Enemy01", 5).Dump();
        NextImageName("Enemy57", 5).Dump();
        NextImageName("Enemy5", 57).Dump();
    }
    
    public static string NextImageName(string filename, int newNumber)
    {
        var re = new Regex(@"\d+$");
        return re.Replace(filename, match =>
        {
            return newNumber.ToString().PadLeft(match.Length, '0');
        });
    }
