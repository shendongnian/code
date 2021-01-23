    public CalcResult TestRun()
    {
        return ProcessData(writeToDatabase: false);
    }
    
    private CalcResult ProcessData(bool writeToDatabase = true)
    {
        DataModel data = QueryData();
    
        CalcResult result = DoCalculations(dataModel);
    
        if (writeToDatabase) UpdateDatabase(result);
    
        return result;
    }
    
    private void UpdateDatabase(CalcResult result)
    {
        //Write data to database
    }
