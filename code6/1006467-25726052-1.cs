    public ResponseMessageResult CreatedObject(string location, object createdObject)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string json = serializer.Serialize(new { value = new[] { createdObject } });
        // Create the response and add the 201 response code
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);            
        response.Headers.Add("Location", location);
        response.Content = new System.Net.Http.StringContent(json);
        // return the result
        return ResponseMessage(response);
    }
