    class Program
    {
        private static HttpListener _listener;
        static void Main(string[] args)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost/asynctest/");
            _listener.Start();
            _listener.BeginGetContext(OnContext, null);
            Console.ReadLine();
        }
        private static void OnContext(IAsyncResult ar)
        {
            var ctx = _listener.EndGetContext(ar);
            _listener.BeginGetContext(OnContext, null);
            Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " Handling request");
            var buf = Encoding.ASCII.GetBytes("Hello world");
            ctx.Response.ContentType = "text/plain";
            // simulate work
            Thread.Sleep(10000);
            ctx.Response.OutputStream.Write(buf, 0, buf.Length);
            ctx.Response.OutputStream.Close();
            Console.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss.fff") + " completed");
        }
    }
