    private bool MobilePhoneSeriesValidation(string num)
    {
         long numLong = long.Parse(num);
         return res.Any(c=> c.SeriesStart <=numLong &&  c.SeriesEnd  >= numLong );
    }
    
    
