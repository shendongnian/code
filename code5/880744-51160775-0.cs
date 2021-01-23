    [Theory]
    [InlineData("en-US","44.00")]
    [InlineData("es-PE", "44,00")]
    [InlineData("es-PE", "44.00")]
    [InlineData("es-PE", "0.01E-15")]
    [InlineData("es-PE", "0,01E-15")]
    public void ParsesDeciaml(string culture, string dec)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        decimal d;
        if (!decimal.TryParse(dec, out d)
            && !decimal.TryParse(
                    dec,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.CurrentCulture,
                    out d
                )
            && !decimal.TryParse(
                    dec,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out d
                )
        ) Assert.False(true, dec);
    }
    
