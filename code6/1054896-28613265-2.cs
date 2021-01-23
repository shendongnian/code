    private static object GetDeserializedObject(ControllerContext controllerContext)
    {
        if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
        {
        // not JSON request
        return null;
        }
        StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
        string bodyText = reader.ReadToEnd();
        if (String.IsNullOrEmpty(bodyText))
        {
            // no JSON data
            return null;
        }
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        object jsonData = serializer.DeserializeObject(bodyText);
        return jsonData;
    }
