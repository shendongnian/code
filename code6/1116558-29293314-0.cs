    public JsonQuery(bool testing = false)
    {
        SmartsheetQuery smartsheetQuery = new SmartsheetQuery();
        if (testing)
             jObject = JObject.Parse(smartsheetQuery.getJsonAsString(unitTestingWorkSheet));
        else
             jObject = JObject.Parse(smartsheetQuery.getJsonAsString(currentWorkSheet));
    }
