    internal static int _closureVariable = 42;
    public static bool checkName(Property prop)
    {
         return prop.Id == _closureVariable;
    }
