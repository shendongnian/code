    [TestFixture]
    public class MyControllerTests
    {    
        [Test]
        public void Get_WithIdLessThan0_ReturnsBadRequest()
        {
            var controller = new MyController();
            int id = -1;
    
            IHttpActionResult actionResult = controller.Get(id);
    
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(actionResult);
        }
    }
