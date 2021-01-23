    if (Char.IsControl(ch))
    {
        // The value is not needed until you know its a control char
        int val = (int)Char.GetNumericValue(ch);
        if (mapping.ContainsKey(val))
        {
            // You know what the control char is, so output its name
            outStr.Append(mapping[val]);
        }
        else
        {
           // You might have missed a control char in your dictionary of names
           // So by default output its hex value instead
           outStr.AppendFormat("<{0}>", val.ToString("X"));  
        }
    }
    else
    {
        // Char is not a control char
        outStr.Append(ch);
    }
    
