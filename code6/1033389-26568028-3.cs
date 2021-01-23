    internal static ObjectResult<GetLookupTable_Result> FunctionThatGetsSprocResult()
    {
        ObjectResult<GetLookupTable_Result> result;
        using (dbContext db = new dbContext())
        {
            result = db.GetLookupTable();               
        }
        result.ToList();
        return result;          
    }
