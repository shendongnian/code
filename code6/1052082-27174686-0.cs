    [Test]
    public void CurrencySymbolShouldAppearBeforeValue()
    {
        decimal price = 1370m;
        var formatInfo = CultureInfo.GetCultureInfo("de-DE")
                                    .NumberFormat.Clone() as NumberFormatInfo;
    
        Assert.IsNotNull(formatInfo);
    
        formatInfo.CurrencyPositivePattern = 2;
    
        string formated = price.ToString("C3", formatInfo);
        Assert.IsNotNull(formated);
    }
