    [Test]
    public void ShouldGetAListOfUsersAndReturnStatusOk ()
    {
        // Setup
        var request = new RestRequest( "/users/", Method.GET ) { RequestFormat = DataFormat.Json, };
        // Execute
        var response = Client.Execute( request );
        // Assert
        Assert.That( response.ErrorMessage, Is.Null );
        Assert.That( response.StatusCode, Is.EqualTo( HttpStatusCode.OK ) );
        _restSchemaValidator.ValidateResponse( "ExpectedUsersResponse.json", response.Content );
        Trace.Write( response.Content );
    }
