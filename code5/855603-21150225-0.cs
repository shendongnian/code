    foreach (string line in new LineReader(() => new StringReader(text))
    {
        string input = "Booking ID: 27620";
        string result = Regex.Replace(input, @"[^\d]", "");
        Console.WriteLine(result); // >> 27620
    }
