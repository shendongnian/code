    public static void SetValueIntOrStr(this ExcelRangeBase range, object value)
    {
    	string strVal = value.ToString();
    	if (!String.IsNullOrEmpty(strVal))
    	{
    		double dVal;
    		int iVal;
    
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
