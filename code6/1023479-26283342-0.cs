    [TestClass]
    public class VertrueSignupViewTests
    {
        private SplContextProvider _splProvider = new SplContextProvider();
        private IVertrueSignupView _form = MockRepository.GenerateMock<IVertrueSignupView>();
        private IFeatureToggle _toggle = MockRepository.GenerateMock<IFeatureToggle>();
        HttpContextBase mockHttpContext = MockRepository.GenerateMock<HttpContextBase>();
        HttpRequestBase mockRequest = MockRepository.GenerateMock<HttpRequestBase>();
        HttpResponseBase mockResponse = MockRepository.GenerateMock<HttpResponseBase>();
        HttpSessionStateBase httpSessionState = MockRepository.GenerateMock<HttpSessionStateBase>();
        [TestMethod]
        public void ButtonSubmitTest()
        {
            mockHttpContext.Stub(x => x.Request).Return(mockRequest);
            mockHttpContext.Stub(x => x.Session).Return(httpSessionState);
            mockHttpContext.Stub(x => x.Response).Return(mockResponse);
            _toggle.Stub(t => t.IsOn()).Return(true);
            var uri =
                new Uri(
                    "http://mypc.local/");
            mockRequest.Stub(u => u.Url).Return(uri);
            mockRequest.Stub(u => u.QueryString)
                .Return(col);
            HttpContextFactory.SetCurrentContext(mockHttpContext);
            //...
        }
