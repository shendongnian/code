    public static string ReadNullTerminatedString(this System.IO.BinaryReader stream)
    {
        string str = "";
        char ch;
        while ((int)(ch = stream.ReadChar()) != 0)
            str = str + ch;
        return str;
    }
