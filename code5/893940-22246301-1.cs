    public class TestService : Service
    {
        [AddHeader(ContentType = "application/xml")]
        public TestResponse Get(RootRequest request)
        {
            return new TestResponse { Message = "Hello from root" };
        }
    }
