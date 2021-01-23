    var testController = new MixedCodeStandardController();
    var getResult = testController.Get();
    var getResponse = getResult.ExecuteAsync(CancellationToken.None).Result;
    Assert.IsTrue(getResponse.IsSuccessStatusCode);
    Assert.AreEqual(HttpStatusCode.Success, getResponse.StatusCode);
    var idResult = testController.Get(1);
    var idResponse = idResult.ExecuteAsync(CancellationToken.None).Result;
    Assert.IsTrue(idResponse.IsSuccessStatusCode);
    Assert.AreEqual(HttpStatusCode.Success, idResponse.StatusCode);
