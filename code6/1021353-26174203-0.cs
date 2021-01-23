    public enum Mode
    {
        AlphaNumeric = 1,
        Alpha = 2,
        Numeric = 3
    }
    public static string Increment(string text, Mode mode)
    {
        var textArr = text.ToCharArray();
        // Add legal characters
        var characters = new List<char>();
        if (mode == Mode.AlphaNumeric || mode == Mode.Numeric)
            for (char c = '0'; c <= '9'; c++)
                characters.Add(c);
        if (mode == Mode.AlphaNumeric || mode == Mode.Alpha)
            for (char c = 'a'; c <= 'z'; c++)
                characters.Add(c);
        // Loop from end to beginning
        for (int i = textArr.Length - 1; i >= 0; i--)
        {
            if (textArr[i] == characters.Last())
            {
                textArr[i] = characters.First();
            }
            else
            {
                textArr[i] = characters[characters.IndexOf(textArr[i]) + 1];
                break;
            }
        }
            
        return new string(textArr);
    }
    // Testing
    var test1 = Increment("0001", Mode.AlphaNumeric);
    var test2 = Increment("aab2z", Mode.AlphaNumeric);
    var test3 = Increment("0009", Mode.Numeric);
    var test4 = Increment("zz", Mode.Alpha);
    var test5 = Increment("999", Mode.Numeric);
    var test6 = Increment("zz", Mode.Alpha);
