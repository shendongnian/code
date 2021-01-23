     public string MinRateString {get;set;}
    
     public double? MinRate  
     {
            get { return MinRateString ?? "NULL"; }
            set { MinRateString = value.ToString(); }
      }
