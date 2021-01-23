    public class MyClassDerived : MyClassBase
    {
        private EventHandler _myEvent;
        public override event EventHandler MyEvent
        {
            add { _myEvent += value; }
            remove { _myEvent -= value; }
        }
    }
