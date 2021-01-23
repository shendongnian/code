    public class TheLogger : IHttpModule
    {
        HttpApplication _ctx;
        public void Dispose()
        {
            
        }
        public void Init(HttpApplication context)
        {
            _ctx = context;
            _ctx.Error += _ctx_Error;
        }
        void _ctx_Error(object sender, EventArgs e)
        {
            var ex = _ctx.Server.GetLastError();
            File.AppendAllText("c:\\log.txt", ex.ToString());
        }
    }
