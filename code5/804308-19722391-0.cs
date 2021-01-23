    while (!sr.EndOfStream)
    {
        var inputChar = (char)sr.Read();
        input.Append(inputChar);
        if (StringBuilderEndsWith(input, Environment.NewLine))
        {
            var line = input.ToString();
            input = new StringBuilder();
            Debug.WriteLine(line);
        }
        else if (StringBuilderEndsWith(input, "Password:"))
        {
            Debug.WriteLine("Password Prompt Found, Entering Password");
            proc.StandardInput.WriteLine("thepassword");
            var line = input.ToString();
            input = new StringBuilder();
            Debug.WriteLine(line);
        }
    }
    private static bool StringBuilderEndsWith(StringBuilder haystack, string needle)
    {
        var needleLength = needle.Length - 1;
        var haystackLength = haystack.Length - 1;
        for (int i = 0; i < needleLength; i++)
        {
            if (haystack[haystackLength - i] != needle[needleLength - i])
            {
                return false;
            }
        }
        return true;
    }
