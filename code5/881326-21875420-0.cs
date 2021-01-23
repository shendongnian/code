    string s = "{\"id\":\"1234567890\"}";
    char[] array = s.Where(c => Char.IsDigit(c)).ToArray();
    string s1 = new string(array);
    int i;
    if (Int32.TryParse(s1, NumberStyles.Integer, CultureInfo.InvariantCulture, out i))
    {
        Console.WriteLine(i);
    }
