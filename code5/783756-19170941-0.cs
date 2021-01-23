    [TestMethod]
    [ExpectedException(typeof(HttpResponseException))]
    public void Controller_Throws()
    {
      try{
           //setup and inject any dependencies here, using Mocks, etc
           var sut = new TestController();
           //pass any required Action parameters here...
           sut.GetSomething();
         }
        catch(HttpResponseException ex)
        {
           Assert.AreEqual(ex.Response.StatusCode,
               HttpStatusCode.BadRequest,
               "Wrong response type");
    throw;
         }
    }
