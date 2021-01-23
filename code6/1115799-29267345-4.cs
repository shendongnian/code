    private decimal? _totalAdjusted == null;
    
    public decimal TotalAdjusted
    {
        set { _totalAdjusted = value;  }
        get 
        { 
            return _totalAdjusted.HasValue ? _totalAdjusted.Value : ComputeHours();  
        }
    }
