        public partial class MyService : ServiceBase
        {
            private Object _foo;
            private const string _logName = "MyService Log.txt"; // to support added logging
            public Service1()
            {
                InitializeComponent();
            }
            protected override void OnStart(string[] args)
            {
                // demonstrative logging added
                var threadId = Thread.CurrentThread.ManagedThreadId;
                using (var log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"_logName", true))
                {
                    log.WriteLine("{0}:  In OnStart(string[]) on thread ID {1}.", DateTime.Now, threadId);
                }
                _foo = new Object();
            }
            protected override void OnStop()
            {
                // demonstrative logging added
                var threadId = Thread.CurrentThread.ManagedThreadId;
                using (var log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"_logName", true))
                {
                    log.WriteLine("{0}:  In OnStop() on thread ID {1}.", DateTime.Now, threadId);
                }
                if (_foo == null)
                {
                    // demonstrative logging added
                    using (var log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"_logName", true))
                    {
                        log.WriteLine("{0}:  _foo == null", DateTime.Now);
                    }
                    throw new Exception("Assignment not visible"); // Can this happen?
                }
                _foo = null;
            }
        }
