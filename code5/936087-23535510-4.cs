    var apiResponse = new ApiResponse() { api_name = "test api" };                
    using (stringwriter = new StringWriter())
    {
        var ser = new System.Xml.Serialization.XmlSerializer(
        typeof(ApiResponse));
        ser.Serialize(stringwriter,apiResponse);
        var xmlString= stringwriter.GetStringBuilder().ToString();
        return xmlString;
    }
                
