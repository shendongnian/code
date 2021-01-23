    public async Task<List<IHFData>> GetHFServiceData(string wtTransfereeId)
    {
        var hfDataList = new List<HFData>();
    
        foreach(var item in aauthorizationList)
        {
            // code to retrieve data from database (truncated)
            HFData hfData = await Db.hfAuthorizations.AsNoTracking()....SingleOrDefaultAsync(); //This method is now async.
    
            hfDataList.Add(hfData);
        }
    
        //just return the list when you are done.
        return hfDataList; 
    }
