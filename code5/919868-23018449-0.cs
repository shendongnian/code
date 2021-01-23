    public string GetHasImage(){ return HasImage ? "Yes" : "No"; }
    
    public string GetDateTimeOffset 
    {
        return 
            !StartDate.HasValue ? string.Empty : 
            StartDate == DateTime.Today.Date ? 1 Day" : 
            StartDate < DateTime.Today.Date ? "Past Due" : 
            string.Empty;
    }
