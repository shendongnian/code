    public static void ConvertValueToAppropriateTypeAndAssign(this ExcelRangeBase range, object value)
    {
        string strVal = value.ToString();
        if (!String.IsNullOrEmpty(strVal))
        {
            decimal decVal;
            double dVal;
            int iVal;
    
            if (decimal.TryParse(strVal, out decVal))
                range.Value = decVal;
            if (double.TryParse(strVal, out dVal))
                range.Value = dVal;
            else if (Int32.TryParse(strVal, out iVal))
                range.Value = iVal;
            else
                range.Value = strVal;
        }
        else
            range.Value = null;
    }
