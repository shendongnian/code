    public static void CopyIfDifferent(ref string vValueToCopyTo, string vValueToCopyFrom)
    {
        if (!ValuesAreEqual(vValueToCopyTo, vValueToCopyFrom))
        {
            vValueToCopyTo = vValueToCopyFrom;
        }
    }
