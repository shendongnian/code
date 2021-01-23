    HttpResponseException expectedException = null;
    try
    {
    	await  client.LoginAsync("notarealuser@example.com", testpassword));         
    }
    catch (HttpResponseException ex)
    {
    	expectedException = ex;
    }
    
    Assert.AreEqual(HttpStatusCode.NoContent, expectedException.Response.BadRequest);
