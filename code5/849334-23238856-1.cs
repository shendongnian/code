    private static System.Globalization.NumberFormatInfo SetupNumberFormatInfo()
    { 
        //System.Globalization.NumberFormatInfo nfi = (System.Globalization.NumberFormatInfo)System.Globalization.CultureInfo.InvariantCulture.NumberFormat.Clone();
        System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
        nfi.NumberGroupSeparator = "'";
        nfi.NumberDecimalSeparator = ".";
    
        nfi.CurrencyGroupSeparator = "'";
        nfi.CurrencyDecimalSeparator = ".";
        nfi.CurrencySymbol = "CHF";
    
        return nfi;
    } // End Function SetupNumberFormatInfo
    
    
    private static System.Globalization.NumberFormatInfo m_nfi = SetupNumberFormatInfo();
    
    
    public static string ToNumberString(this double dblQuantity)
    {
        return ToNumberString(dblQuantity, "N0");
    }
    
    
    public static string ToNumberString(this double dblQuantity, string Format)
    {
        // http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo%28VS.71%29.aspx
    
        //double dblQuantity = -123456789.123456789;
        //string strFormattedInteger = dblQuantity.ToString("N0", m_nfi);
        //strFormattedInteger = string.Format(m_nfi, "{0:N0}", dblQuantity);
    
        return dblQuantity.ToString(Format, m_nfi);
    }
