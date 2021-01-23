    private bool MobilePhoneSeriesValidation(string num)
    {
         long numLong = long.Parse(num);
         var res = DummyGetMobilePhoneSeries();
         return res.Any(c=> c.SeriesStart <=numLong &&  c.SeriesEnd  >= numLong );
    }
    
    
