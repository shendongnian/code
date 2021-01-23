    string frFR = string.Format(new System.Globalization.CultureInfo("fr-FR"),
                (new CultureInfo("fr-FR")).NumberFormat.CurrencyPositivePattern % 2 == 0 ?
                       "{0}{1:#,##0.##}" : "{1:#,##0.##}{0}", 
                new RegionInfo(new CultureInfo("fr-FR").LCID).ISOCurrencySymbol, price);
    string frFR2 = string.Format(new System.Globalization.CultureInfo("fr-FR"), 
                (new CultureInfo("fr-FR")).NumberFormat.CurrencyPositivePattern % 2 == 0 ?
                       "{0}{1:#,##0.##}" : "{1:#,##0.##}{0}",
                new RegionInfo(new CultureInfo("fr-FR").LCID).ISOCurrencySymbol, price2);
    string co = string.Format(new System.Globalization.CultureInfo("es-CO"),
                (new CultureInfo("es-CO")).NumberFormat.CurrencyPositivePattern % 2 == 0 ? 
                       "{0}{1:#,##0.##}" : "{1:#,##0.##}{0}",
                new RegionInfo(new CultureInfo("es-CO").LCID).ISOCurrencySymbol, price);
    string co2 = string.Format(new System.Globalization.CultureInfo("es-CO"),
                (new CultureInfo("es-CO")).NumberFormat.CurrencyPositivePattern % 2 == 0 ? 
                       "{0}{1:#,##0.##}" : "{1:#,##0.##}{0}",
                new RegionInfo(new CultureInfo("es-CO").LCID).ISOCurrencySymbol, price2);
