    public class Client
    {
        static void Main(string[] args)
        {
            var client = new MyRequest(OnSuccess);
            client.Function();
            //Output:
            //I'm in the callback
            //Foo.Bar()
            Console.ReadKey();
        }
        static void OnSuccess(string result)
        {
            Console.WriteLine("I'm in the callback");
            Console.WriteLine(result);
        }
    }
    public class Network
    {
        public void SendMyRequest(MyRequest request)
        {
            var result = "Foo.Bar()";
            if (!String.IsNullOrEmpty(result))
            {
                request.SuccessCallback(result);
            }
        }
    }
    public class MyRequest
    {
        public Action<string> SuccessCallback { get; private set; }
        private Network _network;
        public MyRequest(Action<string> successCallback)
        {
            _network = new Network();
            SuccessCallback = successCallback;
        }
        public void Function()
        {
            _network.SendMyRequest(this);
        }
    }
