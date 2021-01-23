    public string GetSubstringByString(string a, string b, string c)
    {
        int aPos = c.IndexOf(a);
        int bPos = c.IndexOf(b,aPos);
        return c.Substring((aPos + a.Length), (bPos - c.IndexOf(a) - a.Length));
    }
