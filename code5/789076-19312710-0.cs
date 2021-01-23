    public class AccountListener
    {
        private Thread _worker = null;
        private MobileAccount _mobileAccount;
        public AccountListener(MobileAccount mobileAccount)
        {
            _mobileAccount = mobileAccount;
        }
        protected void Listen()
        {
            try
            {
                DoWork();
            }
            catch (Exception exc)
            {
            }
        }
        protected virtual void DoWork()
        {
            Console.WriteLine(_mobileAccount);
        }
        public void Start()
        {
            if (_worker == null)
            {
                _worker = new Thread(Listen);
            }
            _worker.Start();
        }
        public void Stop()
        {
            try
            {
                _worker.Abort();
            }
            catch (Exception)
            {
                //thrad abort exception
            }
            finally
            {
                _worker = null;
            }
        }
    }
