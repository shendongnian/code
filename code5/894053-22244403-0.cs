    public class HttpProxy : IDisposable
    {
        public HttpProxy()
        {
            Fiddler.FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            Fiddler.FiddlerApplication.Startup(8888, true, true);
        }
        void FiddlerApplication_BeforeRequest(Fiddler.Session oSession)
        {
            Console.WriteLine(String.Format("REQ: {0}", oSession.url));
        }
        public void Dispose()
        {
            Fiddler.FiddlerApplication.Shutdown();
        }
    }
    static void Main(string[] Args)
    {
        var p = new HttpProxy();
        Console.ReadLine();
        p.Dispose();
    }
