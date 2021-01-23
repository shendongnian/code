    private bool MobilePhoneSeriesValidation(long num)
    {
        var res = DummyGetMobilePhoneSeries();
        return res.Any(c=> c.SeriesStart <=numLong &&  c.SeriesEnd  >= numLong );    
    }
