    public JsonQuery()
    {
        SmartsheetQuery smartsheetQuery = new SmartsheetQuery();
    #if TEST
        jObject = JObject.Parse(smartsheetQuery.getJsonAsString(unitTestingWorkSheet));
    #else
        jObject = JObject.Parse(smartsheetQuery.getJsonAsString(currentWorkSheet));
    #endif
    }
