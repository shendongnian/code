    public static List<object[]> Serialise2D_Rec(IEnumerable data, Type t)
    {
        …
        for (…)
        {
            if (…)
            {
            }
            else
            {
                …
                List<object[]> serialisedProp = Serialise2D_Rec(lst, proptype);
            }
        }
    }
