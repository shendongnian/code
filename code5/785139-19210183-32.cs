    [Test]
    public void MyTest()
    {
        // first do any necessary database setup. Or you could have a
        // test be a whole end-to-end use case where you do Post/Put 
        // requests to create a resource, Get requests to query the 
        // resource, and Delete request to delete it.
        // I use RestSharp as a way to test the request/response 
        // a little more independently from the ServiceStack framework.
        // Alternatively you could a ServiceStack client like JsonServiceClient.
        var client = new RestClient(ServiceTestAppHost.BaseUrl);
        client.Authenticator = new HttpBasicAuthenticator(NUnitTestLoginName, NUnitTestLoginPassword);
        var request = new RestRequest...
        var response = client.Execute<ResponseClass>(request);
        // do assertions on the response object now
    }
