    private static Dictionary<string, object> __backingFields = new Dictionary<string, object>();
    public static string Prop
    {
        get
        { 
            return __backingFields.ContainsKey("Prop") ? 
                         __backingFields["Prop"] as string : 
                         default(string); 
        }
        set
        {
            var manipulatedValue = applyOtherCode(value); // the rest of the code
            if (__backingFields.ContainsKey("Prop")) 
                __backingFields["Prop"] = manipulatedValue;
            else __backingFields.Add("Prop", manipulatedValue);
        }
    }
    // There is no field for anyone to mistakenly access!
