    Task<DbOneResults> dbOne= GetDbOneRecords();
    Task<DbTwoResults> dbTwo = GetDbTwoRecords();
    Task<DbThreeResults> dbThree = GetDbThreeRecords();
    //This line is not necessary, but if you wanted all 3 done before you 
    //started to process the results you would use this. 
    await Task.WhenAll(dbOne, dbTwo, dbThree);
    //Use the results from the 3 tasks, its ok to await a 2nd time, it does not hurt anything.
    DbOneResults dbOneResults = await dbOne;
    DbTwoResults dbTwoResults = await dbTwo;
    DbThreeResults dbThreeResults = await dbThree;
