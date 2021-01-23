    public static string ToFormattedText(this MyEnum value)
    {
        var stringVal = value.ToString();   
        var bld = new StringBuilder();
    
        for (var i = 0; i < stringVal.Length; i++)
        {
            // checking i > 0 because we don't want to add space
            // at the beggining
            if (i > 0 && char.IsUpper(stringVal[i]))
            {
                bld.Append(" ");
            }
    
            bld.Append(stringVal[i]);
        }
    
        return bld.ToString();
    }
