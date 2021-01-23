    public dynamic GetData()
    {
         dynamic objReturn = new ExpandoObject();
         objReturn.Id = "ABC123";
         objReturn.name = "ABC";
         JavaScriptSerializer objSerializer = new JavaScriptSerializer();
         return objSerializer.Serialize(objReturn);
    }
