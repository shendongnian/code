    public List<PriceRow> GetABSPriceRows(string dekorNr, string bezeichnung, string hersteller)
    {
        IEnumerable<PriceRow> lstFoundPriceRows = _lstABSPriceRows; //_lstABSPriceRows is the source list
    
        lstFoundPriceRows = lstFoundPriceRows.Where(p => string.IsNullOrWhitespace(dekorNr) || p.Artikelnummer.Contains(dekorNr));
    
        lstFoundPriceRows = lstFoundPriceRows.Where(p => string.IsNullOrWhitespace(bezeichnung) || p.Bezeichnung.Contains(bezeichnung));
    
        lstFoundPriceRows = lstFoundPriceRows.Where(p => string.IsNullOrWhitespace(hersteller) || p.Lieferant.Contains(hersteller));
    
        return lstFoundPriceRows.ToList();
    }
