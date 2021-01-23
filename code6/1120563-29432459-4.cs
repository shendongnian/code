    string cardNumber = "1234567890123456";
    string[] subStrings = Enumerable.Range(0, 4)
        .Select(n => cardNumber.Substring(n * 4, 4)).ToArray();
    string result = String.Format("{0}-{1}-{2}-{3}", subStrings);
    Console.WriteLine(result);
