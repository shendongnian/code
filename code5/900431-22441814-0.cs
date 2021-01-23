    public interface IWidget
    {
        void DoSomethingPublic();
    }
    public class SomeObject
    {
        private ObjectWidget _myWidget = new ObjectWidget();
        public IWidget MyWidget
        {
            get { return _myWidget; }
        }
        private class ObjectWidget
        {
            public void DoSomethingPublic()
            {
                // implement the interface
            }
            public void DoSomethingPrivate()
            {
                // this method can only be called from within SomeObject
            }
        }
    }
