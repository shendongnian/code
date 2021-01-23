    public double? GetSignalAverage
    {
        get
        {
           if(Gsmdata == null || GsmData.Count() == 0)
               return null;
             
           var signalaverage = Gsmdata.Select(x => x.SignalStrength)
                                      .Average();
           return Math.Round(signalaverage, 2);
        }
    }
