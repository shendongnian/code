    public static StringParameters At(this string text, char c, Func<int> startFunc)
    {
        int start = startFunc();
        int index = text.IndexOf(c);
        if (index > 0)
        {
            int index2 = text.IndexOf(c, index + 1);
            if (index2 > index)
            {
                text = text.Substring(0, text.Length - index2);
            }
            return new StringParameters(text, index2 + 1);
        }
        return new StringParameters(null, -1);
    }
