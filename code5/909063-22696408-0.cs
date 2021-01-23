     public static int? ToNullableInt32(string s)
    {
        int i;
        return (Int32.TryParse(s, out i)) ? i : null;
    }
