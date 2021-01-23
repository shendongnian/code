    foreach (var webServiceRespone in response.Values)
    {
        PropertyInfo propInfo = myObject.GetType().GetProperty(webServiceResponse.Name);
        if (propInfo != null)
            propInfo.SetValue(myObject, webServiceResponse.Value);
    }
