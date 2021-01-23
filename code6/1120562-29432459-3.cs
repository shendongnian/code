    string cardNumber = "1234567890123456";
    IEnumerable<string> subStrings = Enumerable.Range(0, 4)
        .Select(n => cardNumber.Substring(n * 4, 4));
    string result = String.Join("-", subStrings);
    Console.WriteLine(result);
