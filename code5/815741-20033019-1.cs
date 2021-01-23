    var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
    string frFR = string.Format(new System.Globalization.CultureInfo("fr-FR"), 
                "{0}{1:#,##0.##}", ri.ISOCurrencySymbol, price);
    string frFR2 = string.Format(new System.Globalization.CultureInfo("fr-FR"), 
                "{0}{1:#,##0.##}", ri.ISOCurrencySymbol, price2);
    string co = string.Format(new System.Globalization.CultureInfo("es-CO"), 
                "{0}{1:#,##0.##}", ri.ISOCurrencySymbol, price);
    string co2 = string.Format(new System.Globalization.CultureInfo("es-CO"), 
                "{0}{1:#,##0.##}", ri.ISOCurrencySymbol, price2);
