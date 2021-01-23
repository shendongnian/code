    public void GetReport1Data()
    {
        var reportData = msEntity.REP_MM_DEMOGRAPHIC.AsEnumerable(); 
        var resultData = from c in reportData
                       join p in PG_MEMBER on c.MemberID equals p.MemberID
    
        ... do other stuff
    
    }
    
    public void GetReport2Data()
    {
        var reportData = msEntity.REP_MM_BIRTHDAY.AsEnumerable(); 
        var resultData = from c in reportData
                       join p in PG_MEMBER on c.MemberID equals p.MemberID
    
        ... do other stuff
    
    }
