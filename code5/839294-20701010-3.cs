    public List<PriceRow> GetABSPriceRows(string dekorNr, string bezeichnung, string hersteller)
    {
        IEnumerable<PriceRow> lstFoundPriceRows = _lstABSPriceRows; //_lstABSPriceRows is the source list
    
        if (!string.IsNullOrWhitespace(dekorNr))
            lstFoundPriceRows = lstFoundPriceRows.Where(p => p.Artikelnummer.Contains(dekorNr));
    
        if (!string.IsNullOrWhitespace(bezeichnung))
            lstFoundPriceRows = lstFoundPriceRows.Where(p => p.Bezeichnung.Contains(bezeichnung));
    
        if (!string.IsNullOrWhitespace(hersteller))
            lstFoundPriceRows = lstFoundPriceRows.Where(p => p.Lieferant.Contains(hersteller));
    
        return lstFoundPriceRows.ToList();
    }
