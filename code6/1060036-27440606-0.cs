    private static string Escape( string s )
    {
        const string escapeChars = "\\";
        const string chars =@",\#+<>;""=";
        string ret = s;
        for (int i = 0; i < chars.Length; i++)
        {
            ret = ret.Replace(chars.Substring(i, 1), escapeChars + chars[i]);
        }
        //add further code here to handle escaping of leading and trailing white space...
        return ret;
    }
