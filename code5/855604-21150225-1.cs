    string text = "Booking ID: 27620 ..."; 
    foreach (string line in new LineReader(() => new StringReader(text))
    {
        string result = Regex.Replace(line, @"[^\d]", "");
        Console.WriteLine(result); // >> 27620
    }
