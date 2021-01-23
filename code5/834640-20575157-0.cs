    public static StringBuilder builder;
    static void AddToString(string s)
    {
        if(builder == null)
            builder = new StringBuilder(s);
        builder.Append(s);  // new line?: s + "\r\n"
    }
