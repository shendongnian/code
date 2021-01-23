    public static CompareOperators GetTypeForOperator(string strType)
    {
        switch (strType)
        {
            case "=":
                return ...
            default:
                throw new ArgumentException("strType has a unparseable value");
        }
    }
