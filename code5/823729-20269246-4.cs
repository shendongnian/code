    public class Foo : IDisposable
    {
        TcpListener lst;
        public Foo()
        {
            lst = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 9090);
        }
        public void Dispose()
        {
            lst.Stop();
        }
    }
