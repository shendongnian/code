    var testController = new MixedCodeStandardController();
    
    var getResult = testController.Get();
    var posRes = getResult as OkNegotiatedContentResult<object>;
    Assert.IsType<OkNegotiatedContentResult<object>>(getResult);
    Assert.AreEqual(HttpStatusCode.Success, posRes.StatusCode);
    Assert.AreEqual(testController._data, posRes.Content);
    var idResult = testController.Get(1);
    var oddRes = getResult as OkNegotiatedContentResult<object>; // oddRes is null
    Assert.IsType<OkNegotiatedContentResult<object>>(idResult); // throws failed assertion
    Assert.AreEqual(HttpStatusCode.Success, oddRes.StatusCode); // throws for null ref
    Assert.AreEqual(testController._data, oddRes.Content); // throws for null ref
