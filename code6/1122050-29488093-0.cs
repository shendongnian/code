    [TestMethod]
    public async Task ApiClient_ThrowsHttpException401IfNotAuthorised()
    {
        //arrange
        string apiKey = "";
        string endPoint = "payments";
        //act
        try
        {
            HttpResponseMessage response = await ApiClient.SubmitRequest(endPoint, apiKey);
        }
        //assert
        catch (HttpException ex)
        {
            // HttpException is expected
            Assert.AreEqual(401, (int)ex.GetHttpCode());
            Assert.AreEqual("Not authorized.", ex.Message);
        }
        catch (Exception)
        {
            // Any other exception should cause the test to fail
            Assert.Fail();
        }
    }
