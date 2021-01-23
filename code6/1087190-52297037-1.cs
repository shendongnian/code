    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class HelloService : IHelloService
    {
        private int _requestCount;
        public string SayHello()
        {
            _requestCount++;
            return $"Hello this is your {_requestCount} request";
        }
    }
