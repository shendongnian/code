    using System;
    using System.Net;
    using System.Text;
    namespace TestServer
    {
        class ServerMain
        {
            // To enable this so that it can be run in a non-administrator account:
            // Open an Administrator command prompt.
            // netsh http add urlacl http://+:8008/ user=Everyone listen=true
            
            const string Prefix = "http://+:3070/";
            static HttpListener Listener = null;
            static int RequestNumber = 0;
            static readonly DateTime StartupDate = DateTime.UtcNow;
            static void Main(string[] args)
            {
                if (!HttpListener.IsSupported)
                {
                    Console.WriteLine("HttpListener is not supported on this platform.");
                    return;
                }
                using (Listener = new HttpListener())
                {
                    Listener.Prefixes.Add(Prefix);
                    Listener.Start();
                    // Begin waiting for requests.
                    Listener.BeginGetContext(GetContextCallback, null);
                    Console.WriteLine("Listening. Press Enter to stop.");
                    Console.ReadLine();
                    Listener.Stop();
                }
            }
            static void GetContextCallback(IAsyncResult ar)
            {
                int req = ++RequestNumber;
                // Get the context
                var context = Listener.EndGetContext(ar);
                // listen for the next request
                Listener.BeginGetContext(GetContextCallback, null);
                // get the request
                var NowTime = DateTime.UtcNow;
                Console.WriteLine("{0}: {1}", NowTime.ToString("R"), context.Request.RawUrl);
                var responseString = string.Format("<html><body>Your request, \"{0}\", was received at {1}.<br/>It is request #{2:N0} since {3}.",
                    context.Request.RawUrl, NowTime.ToString("R"), req, StartupDate.ToString("R"));
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                // and send it
                var response = context.Response;
                response.ContentType = "text/html";
                response.ContentLength64 = buffer.Length;
                response.StatusCode = 200;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }
    }
