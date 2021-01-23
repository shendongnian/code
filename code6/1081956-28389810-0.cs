    public class ShareHolding
    {
        public ShareHolding(int accountId)
        {
            // do whatever you want
        }
    }
    public class MyApp
    {
        private readonly ShareHolding _shareHolding;
        public MyApp(Func<int, ShareHolding> shareHoldingFactory)
        {
            _shareHolding = shareHoldingFactory(99);
        }
        public void Run()
        {
            // do whatever you want with the _shareHolding object
        }
    }
