    public List<PriceRow> GetABSPriceRows(string dekorNr, string bezeichnung, string hersteller)
    {
        return _lstABSPriceRows
               .Where(p => string.IsNullOrWhitespace(dekorNr) || p.Artikelnummer.Contains(dekorNr))
               .Where(p => string.IsNullOrWhitespace(bezeichnung) || p.Bezeichnung.Contains(bezeichnung))
               .Where(p => string.IsNullOrWhitespace(hersteller || p.Lieferant.Contains(hersteller))
               .ToList();
    }
