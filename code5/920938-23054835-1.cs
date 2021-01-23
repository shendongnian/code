    private static readonly Dictionary<string, int> __intFields = new Dictionary<string, int>();
    private static readonly Dictionary<string, string> __stringFields = new Dictionary<string, string>();
    public static string StringProp
    {
        get
        { 
            var fieldValue = default(string);
            __stringFields .TryGetValue("StringProp", out fieldValue);
            return fieldValue;
        }
        set
        {
            var manipulatedValue = applyOtherCode(value); // the rest of the code
            __stringFields ["StringProp"] = manipulatedValue
        }
    }
    public static int IntProp
    {
        get
        { 
            var fieldValue = default(int);
            __intFields .TryGetValue("IntProp", out fieldValue);
            return fieldValue;
        }
        set
        {
            var manipulatedValue = applyOtherCode(value); // the rest of the code
            __intFields ["IntProp"] = manipulatedValue
        }
    }
    // There is no field for anyone to mistakenly access!
