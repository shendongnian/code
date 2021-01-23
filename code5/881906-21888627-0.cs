    CultureInfo cultureCA = CultureInfo.CreateSpecificCulture("fr-CA");
    NumberFormatInfo numberFormat = cultureCA.NumberFormat;
    numberFormat.CurrencyGroupSeparator = ".";
    numberFormat.CurrencyDecimalSeparator = ",";
	Thread.CurrentThread.CurrentCulture = cultureCA;
	decimal num = Decimal.Parse("2,00$", System.Globalization.NumberStyles.Currency 
    					| System.Globalization.NumberStyles.Number);
	Console.WriteLine(num == 2M);
    // true, num is 2 
   
	num = Decimal.Parse("2.00$", System.Globalization.NumberStyles.Currency 
	                   | System.Globalization.NumberStyles.Number);
	Console.WriteLine(num == 200M);
	// true, num is 200 
