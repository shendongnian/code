    //System.Globalization.NumberFormatInfo nfi = (System.Globalization.NumberFormatInfo)System.Globalization.CultureInfo.InvariantCulture.NumberFormat.Clone();
    System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
                
    nfi.NumberGroupSeparator = "'";
    nfi.NumberDecimalSeparator = ".";
    
    
    // http://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo%28VS.71%29.aspx
    Console.WriteLine((-123456789.123456789).ToString("N0", nfi)); // 12 345.00
