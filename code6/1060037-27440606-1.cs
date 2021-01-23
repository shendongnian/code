    private static string Escape( string s )
    {
        const string escapeChars = "\\";
        const string chars =@",\#+<>;""=";
        string ret = s;
        foreach (char ch in chars)
        {
            ret = ret.Replace(ch.ToString(), escapeChars + ch);
        }
        //add further code here to handle escaping of leading and trailing white space...
        return ret;
    }
