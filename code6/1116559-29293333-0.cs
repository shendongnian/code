     public JsonQuery(string worksheet)
     {
        SmartsheetQuery smartsheetQuery = new SmartsheetQuery();
        jObject = JObject.Parse(smartsheetQuery.getJsonAsString(worksheet));    
     }
