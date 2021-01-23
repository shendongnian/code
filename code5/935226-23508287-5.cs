    public class MyController : ApiController
    {
        public IHttpActionResult Get()
        {
             if (Request.Headers. /* insert your code here */)
             {
                 // Do Something
             }
        }
     }
     public class TestClass
     {
         public void Test()
         {
             // Arrange
             var controller = new MyController();
             var request = new HttpRequestMessage();
             request.Headers... // setup your test here
             // Act
             var result = controller.Get();
             // Assert
             // Verify here
         }
     }
