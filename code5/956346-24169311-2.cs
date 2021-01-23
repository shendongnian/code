    public abstract class MyClassBase
    {
        private EventHandler _myEvent;
        public virtual event EventHandler MyEvent
        {
            add { _myEvent += value; }
            remove { _myEvent -= value; }
        }
    
        public void DoStuff()
        {
            if (_myEvent != null)
            {
                _myEvent(this, EventArgs.Empty);
            }
        }
    }
