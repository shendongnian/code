    Double dblValue;
    Double dblRoundedValue;
    Int32 intValue;
    Int32 intAbsValue;
    String finalValue;
    for (int i = 0; i < values.Length; i++)
    {
        strValue = values[j];
        if (!Int32.TryParse(strValue, out intValue))
        {
            dblValue = Double.Parse(strValue);
            dblRoundedValue = Double.Parse(dblValue);
            intValue = (Int32)dblRoundedValue;
        }
        //intValue  = Math.Abs(intValue);
        //finalValue = intValue .ToString();
    
        file[i].Value = (Math.Abs(intValue)).ToString();
    }
