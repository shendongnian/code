     public double? MinRate {get;set;}
   
      public string MinRateString  
       {
             get {
                    if(MinRate!=null)
                       return MinRate.ToString();
                     else
                       return "Null";
                }
       }
