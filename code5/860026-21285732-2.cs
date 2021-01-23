    public class MyService : IDisposable
    {
        public MyRepository _repos = new MyRepository();
    
        // [...]
        public void Dipose()
        {
            _repos.Dispose();
        }
    }
