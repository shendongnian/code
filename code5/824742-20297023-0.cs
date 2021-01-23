    decimal dollarAmount = 123165.4539M;
    string text = dollarAmount.ToString("C",Cultures.US);
    
    Console.WriteLine(text);
    public static class Cultures
    {
        public static readonly CultureInfo US= 
            CultureInfo.ReadOnly(new CultureInfo("en-US"));
    }
