    private string GetJsonFromBool(bool value)
    {
        var data = new { result = value };
        return new System.Web.Script.Serialization.
            JavaScriptSerializer().Serialize(data);
    }
    // Then use it at your return statement of original method, like
    return GetJsonFromBool(true); // or false
    
