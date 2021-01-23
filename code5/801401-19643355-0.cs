    public class MyUsing :
        IDisposable
    {
        private Action _disposeAction;
        public MyUsing(
            Action disposeAction)
        {
            _disposeAction = disposeAction;
        }
        public void Dispose()
        {
            var h = _disposeAction;
            _disposeAction = null;
            if (h != null)
            {
                h();
            }
        }
    }
