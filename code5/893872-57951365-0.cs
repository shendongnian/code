public abstract class AbstractHandler : HttpClientHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(SendAsync(request.Method, request.RequestUri.AbsoluteUri));
    }
    public abstract HttpResponseMessage SendAsync(HttpMethod method, string url);
}
Then you can intercept calls to the `HttpClientHandler` like:
// Arrange
var httpMessageHandler = A.Fake<AbstractHandler>(options => options.CallsBaseMethods());
A.CallTo(() => httpMessageHandler.SendAsync(A<HttpMethod>._, A<string>._)).Returns(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Result")});
var httpClient = new HttpClient(httpMessageHandler);
// Act
var result = await httpClient.GetAsync("https://google.com/");
// Assert
Assert.Equal("Result", await result.Content.ReadAsStringAsync());
A.CallTo(() => httpMessageHandler.SendAsync(A<HttpMethod>._, "https://google.com/")).MustHaveHappenedOnceExactly();
More information can be found on this blog: https://www.meziantou.net/mocking-an-httpclient-using-an-httpclienthandler.htm
