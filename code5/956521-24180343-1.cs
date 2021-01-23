    [SpecialName]
    public static string op_Concatenate(CSType c1, string s2)
    {
        return c1.ToString() + s2;
    }
    [SpecialName]
    public static string op_Concatenate(string s1, CSType c2)
    {
        return s1 + c2.ToString();
    }
