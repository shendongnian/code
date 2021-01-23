    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var r1 = new Request {Callback = r => Console.WriteLine(r), Parm1 = "ok1", Parm2 = "language"};
                TextSystem.QueueRequest(r1);
    
                var r2 = new Request {Callback = r => Console.WriteLine(r), Parm1 = "ok2", Parm2 = "language"};
                TextSystem.QueueRequest(r2);
    
                var r3 = new Request {Callback = r => Console.WriteLine(r), Parm1 = "ok3", Parm2 = "language"};
                TextSystem.QueueRequest(r3);
    
                var r4 = new Request {Callback = r => Console.WriteLine(r), Parm1 = "ok4", Parm2 = "language"};
                TextSystem.QueueRequest(r4);
    
                TextSystem.Flush();
    
                Console.Read();
            }
        }
    
        public static class TextSystem
        {
            private static readonly List<Request> requests = new List<Request>();
    
            static TextSystem()
            {
                requests = new List<Request>();
            }
    
            public static void QueueRequest(Request request)
            {
                requests.Add(request);
            }
    
            public async static void Flush()
            {
                List<Tuple<Request, string>> results = await Task.Run(() =>
                    {
                        var list = new List<Tuple<Request, string>>();
    
                        //process each request
                        foreach (Request request in requests)
                        {
                            //Get data, process or whatever
                            list.Add(new Tuple<Request, string>(request, request.Parm1));
                        }
                        return list;
                    });
    
    
                //Callback on same thread as the request was initiated on
                foreach (var result in results)
                {
                    result.Item1.Callback(result.Item2);
                }
            }
        }
    
        public class Request
        {
            public Action<string> Callback { get; set; }
            public string Parm1 { get; set; }
            public string Parm2 { get; set; }
        }
    }
