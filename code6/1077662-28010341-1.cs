    public static string ToFormattedText(this MyEnum value)
    {
        var stringVal = value.ToString();   
        var bld = new StringBuilder();
    
        for (var i = 1; i < stringVal.Length; i++)
        {
            if (char.IsUpper(stringVal[i]))
            {
                bld.Append(" ");
            }
    
            bld.Append(stringVal[i]);
        }
    
        return bld.ToString();
    }
