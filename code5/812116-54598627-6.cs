    public class AccountControllerTests : BaseTest
    {
        private readonly AccountController _accountController;
        public AccountControllerTests()
        {
            _accountController = new AccountController();
            InitializeApiController(_accountController);
        }
        [Test]
        public async Task GetShouldReturnOk()
        {
            var result = await _accountController.Get();
            var response = await result.ExecuteAsync(CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
