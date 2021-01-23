    class MyApiControllerTest
    {
        private MyApiController myApiControllerFixture;
        [TestInitialize]
        void Initialize()
        {
            this.myApiControllerFixture = new MyApiController();
        }
        [TestMethod]
        void MyApiController_Post_ResponseNotNullTest()
        {
            var response = this.myApiControllerFixture.Post(new { });
            Assert.IsNotNull(response);
        }
        [TestMethod]
        void MyApiController_Post_SuccessStatusCodeTest()
        {
            var response = this.myApiControllerFixture.Post(new { });
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
