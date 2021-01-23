    // if your action returns: NotFound()
    IHttpActionResult actionResult = valuesController.Get(10);
    Assert.IsType<NotFoundResult>(actionResult);
    // if your action returns: Ok()
    actionResult = valuesController.Get(11);
    Assert.IsType<OkResult>(actionResult);
    // if your action was returning data in the body like: Ok<string>("data: 12")
    actionResult = valuesController.Get(12);
    OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
    Assert.Equal("data: 12", conNegResult.Content);
    // if your action was returning data in the body like: Content<string>(HttpStatusCode.Accepted, "some updated data");
    actionResult = valuesController.Get(13);
    NegotiatedContentResult<string> negResult = Assert.IsType<NegotiatedContentResult<string>>(actionResult);
    Assert.Equal(HttpStatusCode.Accepted, negResult.StatusCode);
    Assert.Equal("some updated data", negResult.Content);
