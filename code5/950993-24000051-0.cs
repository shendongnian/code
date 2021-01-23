    var testDate = DateTime.Parse("2014-06-15");
    var usa = new System.Globalization.CultureInfo("en-US");
    var portugal = new System.Globalization.CultureInfo("pt-PT");
    var brazil = new System.Globalization.CultureInfo("pt-BR");
    Console.WriteLine(testDate.ToString("d", usa)); // 6/2/2014
    Console.WriteLine(testDate.ToString("d", portugal)); // 02-06-2014
    Console.WriteLine(testDate.ToString("d", brazil)); // 02/06/2014
