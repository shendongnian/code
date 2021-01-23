    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string Validate(string params)
    {
        // your validations
        return "Received : " + params;
    }
