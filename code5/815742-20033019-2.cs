    string frFR = string.Format(new System.Globalization.CultureInfo("fr-FR"), 
                "{0}{1:#,##0.##}", 
                new RegionInfo(new CultureInfo("fr-FR").LCID).ISOCurrencySymbol, price);
    string frFR2 = string.Format(new System.Globalization.CultureInfo("fr-FR"), 
                 "{0}{1:#,##0.##}",
                 new RegionInfo(new CultureInfo("fr-FR").LCID).ISOCurrencySymbol, price2);
    string co = string.Format(new System.Globalization.CultureInfo("es-CO"), 
                 "{0}{1:#,##0.##}",
                 new RegionInfo(new CultureInfo("fr-FR").LCID).ISOCurrencySymbol, price);
    string co2 = string.Format(new System.Globalization.CultureInfo("es-CO"), 
                 "{0}{1:#,##0.##}",
                 new RegionInfo(new CultureInfo("fr-FR").LCID).ISOCurrencySymbol, price2);
