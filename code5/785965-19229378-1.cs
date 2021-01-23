    public class MyApp
    {
        private Random _r;
        public MyApp()
        {
            this._r = new Random();
        }
        public handle_request()
        {
            int n = _r.Next(9);
            String.Format("{0:yyyyMMddHHmmss}{1}", DateTime.Now, n.ToString());
        }
    }
