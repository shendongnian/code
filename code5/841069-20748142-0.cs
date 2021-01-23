    using Moq;
    using NUnit.Framework;
    using SharpTestsEx;
    
    namespace StackOverflowExample.Moq
    {
        public class MyController : Controller
        {
            public string UploadFile()
            {
                return Request.Form["id"];
            }
        }
    
        [TestFixture]
        public class WebApiTests
        {
            [Test]
            public void Should_return_form_data()
            {
                //arrange
                var formData = new NameValueCollection {{"id", "test"}};
                var request = new Mock<HttpRequestBase>();
                request.SetupGet(r => r.Form).Returns(formData);
                var context = new Mock<HttpContextBase>();
                context.SetupGet(c => c.Request).Returns(request.Object);
    
                var myController = new MyController();
                myController.ControllerContext = new ControllerContext(context.Object, new RouteData(), myController);
    
                //act
                var result = myController.UploadFile();
    
                //assert
                result.Should().Be.EqualTo(formData["id"]);
            }
        }
    }
