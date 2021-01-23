    // if your action returns: NotFound()
    IHttpActionResult actionResult = valuesController.Get(10);
    Assert.IsType<NotFoundResult>(actionResult);
    // if your action returns: Ok()
    actionResult = valuesController.Get(11);
    Assert.IsType<OkResult>(actionResult);
    // if your action was returning data in the body like: Ok<string>("data: 12")
    actionResult = valuesController.Get(12);
    OkNegotiatedContentResult<string> conNegResult = actionResult as OkNegotiatedContentResult<string>;
    Assert.NotNull(conNegResult);
    Assert.Equal("data: 12", conNegResult.Content);
    // if your action was returning data in the body like: Content<string>(HttpStatusCode.Created, "some created data");
    actionResult = valuesController.Get(13);
    NegotiatedContentResult<string> negResult = actionResult as NegotiatedContentResult<string>;
    Assert.NotNull(negResult);
    Assert.Equal(HttpStatusCode.Created, negResult.StatusCode);
    Assert.Equal("some created data", negResult.Content);
