    public static bool Equals(String a, String b)
    {
        if ((Object)a == (Object)b)
        {
            return true;
        }
        if ((Object)a == null || (Object)b == null)
        {
            return false;
        }
        if (a.Length != b.Length)
                return false;
        return EqualsHelper(a, b);
    }
