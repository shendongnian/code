    String[] parts = stringVal.Split('.');
    double doubleVal;
    if (parts.length > 1)
    {    
        doubleVal = Convert.ToDouble(parts[0] + "." + parts[1]);
    }
    else
    {
        doubleVale = Convert.ToDouble(stingVal);
    }
