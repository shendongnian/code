    public List<PriceRow> GetABSPriceRows(string dekorNr, string bezeichnung, string hersteller)
    {
        return _lstABSPriceRows
               .Where(p => (dekorNr.IsNullOrWhitespace() || p.Artikelnummer.Contains(dekorNr)) && 
                           (bezeichnung.IsNullOrWhitespace() || p.Bezeichnung.Contains(bezeichnung)) &&
                           (hersteller.IsNullOrWhitespace() || p.Lieferant.Contains(hersteller)))
               .ToList();
    }
