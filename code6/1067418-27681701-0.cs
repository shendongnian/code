    static void Main(string[] args)
    {
        string input = "٢٠١٤-١٢-٢٨T٢١:٤١:٥٨Z";
        string output = ReplaceArabicNumerals(input);
            
        var dateTime = DateTime.Parse(output, null, DateTimeStyles.AssumeUniversal);
        Console.WriteLine(output);
        Console.WriteLine(dateTime.ToString("u");
        Console.ReadKey();
    }
    public static string ReplaceArabicNumerals(string input)
    {
        string output = "";
        foreach (char c in input)
        {
            if (c >= 1632 && c <= 1641)
            {
                output += Char.GetNumericValue(c).ToString();
            }
            else
            {
                output += c;
            }                
        }
        return output;
    }
