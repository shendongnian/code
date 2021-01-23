    namespace WSTest
    {
     class Program
     {
        static void Main(string[] args)
        {
            ServerService ss = new ServerService();
            getResultRequest request = new getResultRequest();
            getResultResponse response = new getResultResponse();
            response = ss.getResultResponse(request);
            // Do something with response.
            Console.ReadLine();
        }
     }
    }
