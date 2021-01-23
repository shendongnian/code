    public void WhatIfCalculation(string Product, string SiteID, List<DAL.OMS_StockStatus> prodStatus, List<PivotViewModel> activityInfo)
    {
        var sff = activityInfo.Where(a => a.Activity == "System Forecast"); // Do this in the calling function >> .Where(a => a.SiteID == SiteID).ToList();
    
        aSFF = new double?[sff.Count()];
        for (var i = 0; i < sff.Count(); i++)
        {
            aSFF[i] = sff.ElementAt(i).Value + 1;
        }
    
        var prf = activityInfo.Where(a => a.Activity == "Planned Receipts");
        aPRF = new double?[prf.Count()];
        for (var i = 0; i < prf.Count(); i++)
        {
            aPRF[i] = prf.ElementAt(i).Value + 2;
        }
    
        // Will perform some calculation here. And then update back my collection.
    
        for (var i = 0; i < aSFF.Length; i++)
        {
            sff.ElementAt(i).Value = aSFF[i];
        }
    
        for (var i = 0; i < aPRF.Length; i++)
        {
            prf.ElementAt(i).Value = aPRF[i];
        }
    }
