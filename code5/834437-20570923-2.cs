    static void Main(string[] args)
    {
        string[] dateValues = { "08:01 AM", "08:01 PM" };
        string[] pattern = new string[] { @"hh\:mm\ \A\M", @"hh\:mm\ \P\M" };
        DateTime parsedDate;
        TimeSpan interval = new TimeSpan();
        foreach (string dateValue in dateValues)
        {
            if (TimeSpan.TryParseExact(dateValue, pattern, null, out interval))
                Console.WriteLine("{0} --> {1}", dateValue, interval.ToString("c"));
            else
                Console.WriteLine("Unable to parse '{0}'", dateValue);
        }
    }
