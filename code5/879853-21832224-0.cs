    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
    var nfi = Thread.CurrentThread.CurrentCulture.NumberFormat;
    Console.WriteLine(nfi.CurrencyDecimalDigits);
    Console.WriteLine(nfi.CurrencyDecimalSeparator);
    Console.WriteLine(nfi.CurrencyNegativePattern);
    Console.WriteLine(nfi.CurrencyPositivePattern);
    Console.WriteLine(nfi.CurrencySymbol);
