    public static void CopyIfDifferent(ref int vValueToCopyTo, int vValueToCopyFrom)
    {
        if (!ValuesAreEqual(vValueToCopyTo, vValueToCopyFrom))
        {
            vValueToCopyTo = vValueToCopyFrom;
        }
    }
    public static bool ValuesAreEqual(int vValue1, int vValue2)
    {
        return vValue1 == vValue2;
    }
