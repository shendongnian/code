    public class TestClass
    {
        public int CallerId = 0;
        [CacheableMethod(30)] // TODO - put to 20 minutes and have value in WebConfig as constant
        public virtual List<MyResponse> GetDataByAccountNumber(int callerId)
        {
            CallerId = callerId;
            var response = StubResponse();
            return response;
        }
        // ...
