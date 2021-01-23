    public static string ToNextAlpha(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
            // Or you can just return "a";
        }
        var end = new StringBuilder();
        for (int index = str.Length - 1; index >= 0; index--)
        {
            char c = str[index];
            bool isZed = c == 'z' || c == 'Z';
            c = (char)(isZed ? c - 25 : c + 1);
            end.Insert(0, c);
            if (!isZed)
            {
                return str.Substring(0, index) + end;
            }
        }
        return "a" + end;
    }
