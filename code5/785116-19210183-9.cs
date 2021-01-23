    [Test(Description = "Ticket # where you implemented the use case the client is paying for")]
    public void MySchemaValidationTest()
    {
        // Send a raw request with a hard-coded URL and request body.
        // Use a non-ServiceStack client for this.
        var request = new RestRequest("/service/endpoint/url", Method.POST);
        request.RequestFormat = DataFormat.Json;
        request.AddBody(requestBodyObject);
        var response = Client.Execute(request);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        restSchemaValidator.ValidateResponse("ExpectedResponse.json", response.Content);
    }
