    static void Main(string[] args)
    {
            decimal d = 12.56m;
            // Different thread cultureinfo
            Thread.CurrentThread.CurrentCulture = 
                new System.Globalization.CultureInfo("de-DE");
            Console.WriteLine(d);
            Thread.CurrentThread.CurrentCulture = 
                new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(d);
            Console.WriteLine(d.ToString(
                new System.Globalization.CultureInfo("de-DE").NumberFormat));
            Console.WriteLine(d.ToString(
                new System.Globalization.CultureInfo("en-US").NumberFormat));
            Console.Read();
    }
