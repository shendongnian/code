    public List<PriceRow> GetABSPriceRows(string dekorNr, string bezeichnung, string hersteller)
    {
      List<PriceRow> lstFoundPriceRows = _lstABSPriceRows; //_lstABSPriceRows is the source list
    
        if (!string.IsNullOrWhitespace(dekorNr) || !string.IsNullOrWhitespace(bezeichnung)|| !string.IsNullOrWhitespace(hersteller) )
          {  
    		lstFoundPriceRows = lstFoundPriceRows.Where (p => p.Artikelnummer.Contains(dekorNr) ||         
    	      p.Bezeichnung.Contains(bezeichnung)||p.Lieferant.Contains(hersteller));   
           }	
    	
    	else
    	{
    	 // Your query without filters
    	}
      }
