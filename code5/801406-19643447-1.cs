    class Program
    {
        static void Main(string[] args)
        {
            bool b = false;
            using (new Sentry(() => b = false))
            {
                // do some stuff
                b = true;
                // do other stuff
            }
    
            System.Diagnostics.Debug.Assert(b == false);
        }
    }
    
    class Sentry : IDisposable
    {
        private Action _action;
        public Sentry(Action disposeAction)
        {
            _action = disposeAction;
        }
    
        public void Dispose()
        {
            if (_action != null)
                _action();
        }
    }
