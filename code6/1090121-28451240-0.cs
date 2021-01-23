    private static bool DoesContain(string predefined, string value)
    {
        char[] c_pre = predefined.ToCharArray();
        char[] c_val = value.ToCharArray();
        char[] intersection = c_pre.Intersect(c_val).ToArray();
        if (intersection.Length == c_val.Length) {
            return true;
        }
        else {
            return false;
        }
    }
