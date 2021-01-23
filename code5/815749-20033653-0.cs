    decimal price = 909865747.98M;
    decimal price2 = 90986574798M;
    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("fr-FR");
    ci.NumberFormat.NumberDecimalDigits = 0;
    string frFR = string.Format(ci, "{0:C}",price);
    string frFR2 = string.Format(ci, "{0:C}", price2);
