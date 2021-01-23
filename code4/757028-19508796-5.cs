        public partial class MyService : ServiceBase
        {
            private Object _foo;
            private const string _logName = "MyService Log.txt"; // to support added logging
            public MyService()
            {
                InitializeComponent();
            }
            protected override void OnStart(string[] args)
            {
                // demonstrative logging
                var threadId = Thread.CurrentThread.ManagedThreadId;
                using (var log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + _logName, true))
                {
                    log.WriteLine("{0}:  In OnStart(string[]) on thread ID {1}.  Sleeping for 10 seconds...", DateTime.Now, threadId);
                }
                // Sleep before initializing _foo to allow calling OnStop before OnStart completes unless the SCM synchronizes calls to the methods.
                Thread.Sleep(10000);
                _foo = new Object();
            }
            protected override void OnStop()
            {
                // demonstrative logging added
                var threadId = Thread.CurrentThread.ManagedThreadId;
                using (var log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + _logName, true))
                {
                    log.WriteLine("{0}:  In OnStop() on thread ID {1}.", DateTime.Now, threadId);
                }
                if (_foo == null)
                {
                    // demonstrative logging added
                    using (var log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + _logName, true))
                    {
                        log.WriteLine("{0}:  _foo == null", DateTime.Now);
                    }
                    throw new Exception("Assignment not visible"); // Can this happen?
                }
                _foo = null;
            }
        }
