    string a = "a";
    string b = "B";
    Console.WriteLine(Comparer<string>.Default.Compare(a, b));
    Console.WriteLine(string.CompareOrdinal(a, b));
    Console.WriteLine(string.Compare(a, b, true, System.Globalization.CultureInfo.InvariantCulture));
    Console.WriteLine(string.Compare(a, b, false, System.Globalization.CultureInfo.InvariantCulture));
