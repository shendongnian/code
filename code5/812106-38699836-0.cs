    var valuesController = controller;
    // if your action returns: NotFound()
    IHttpActionResult actionResult = valuesController.Get(10);
    var notFoundRes = actionResult as NotFoundResult;
    Assert.IsNotNull(notFoundRes);
    // if your action returns: Ok()
    actionResult = valuesController.Get(11);
    var posRes = actionResult as OkResult;
    Assert.IsNotNull(posRes);
    // if your action was returning data in the body like: Ok<string>("data: 12")
    actionResult = valuesController.Get(12);
    var conNegResult = actionResult as OkNegotiatedContentResult<string>;
    Assert.IsNotNull(conNegResult);
    Assert.AreEqual("data: 12", conNegResult.Content);
    // if your action was returning data in the body like: Content<string>(HttpStatusCode.Accepted, "some updated data");
    actionResult = valuesController.Get(13);
    var negResult = actionResult as NegotiatedContentResult<string>;
    Assert.IsNotNull(negResult);
    Assert.AreEqual(HttpStatusCode.Accepted, negResult.StatusCode);
    Assert.AreEqual("some updated data", negResult.Content);
