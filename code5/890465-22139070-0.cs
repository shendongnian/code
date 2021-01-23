    public interface IWebService
    {
        Task<bool> GetDataAsync();
    }
    [TestClass]
    public class AsyncTests
    {
        [TestMethod]
        public async void Test()
        {
            var webService = MockRepository.GenerateStub<IWebService>();
            webService.Expect(x => x.GetDataAsync()).Return(new Task<bool>(() => false));
            var myHandler = new MyCustomHandler(webService);
            bool result = await myHandler.InvokeAsync();
            Assert.IsFalse(result);
        }
    }
