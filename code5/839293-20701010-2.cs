    public List<PriceRow> GetABSPriceRows(string dekorNr, string bezeichnung, string hersteller)
    {
        List<PriceRow> lstFoundPriceRows = _lstABSPriceRows; //_lstABSPriceRows is the source list
    
        if (!string.IsNullOrWhitespace(dekorNr))
            lstFoundPriceRows = lstFoundPriceRows.FindAll(p => p.Artikelnummer.Contains(dekorNr));
    
        if (!string.IsNullOrWhitespace(bezeichnung))
            lstFoundPriceRows = lstFoundPriceRows.FindAll(p => p.Bezeichnung.Contains(bezeichnung));
    
        if (!string.IsNullOrWhitespace(hersteller))
            lstFoundPriceRows = lstFoundPriceRows.FindAll(p => p.Lieferant.Contains(hersteller));
    
        return lstFoundPriceRows;
    }
