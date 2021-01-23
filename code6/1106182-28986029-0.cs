    public static string ToNextAlpha(string str)
    {
        var end = new StringBuilder();
        for (int index = str.Length - 1; index >= 0; index--)
        {
            char c = str[index];
            if (c != 'z' && c != 'Z')
            {
                c = (char)(c + 1);
                end.Insert(0, c);
                return str.Substring(0, index) + end;
            }
            c = (char)(c - 25);
            end.Insert(0, c);
        }
        return "a" + end;
    }
