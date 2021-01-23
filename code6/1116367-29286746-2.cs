    public class MyWrappedClass
    {
        private class LogSessionToken : IDisposable
        {
            private MyWrappedClass parent;
            public LogSessionToken (MyWrappedClass parent)
            {
                parent.LogIn();
            }
            public void Dispose()
            {
                parent.LogOut();
            }
        }
        public IDisposable LogSession()
        {
            return new LogSessionToken (this);
        }
         // ...
    }
