    [TestFixture]
    public class MyControllerTests
    {
        MyController _controller = new MyController();
    
        [Test]
        public void Get_WithIdLessThan0_ReturnsBadRequest()
        {
            int id = -1;
    
            IHttpActionResult actionResult = _controller.Get(id);
    
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(actionResult);
        }
    }
