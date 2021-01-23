    public class SomeEventHolder
    {
        public delegate void SomeEventHandler(bool par);
        public event SomeEventHandler SomeEvent;
        protected virtual void OnSomeEvent(bool par)
        {
            var handler = SomeEvent;
            if (handler != null) handler(par);
        }
    }
