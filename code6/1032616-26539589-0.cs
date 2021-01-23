    class A
    {
        public class B
        {
            protected ManualResetEvent _event = new ManualResetEvent(false);
            public void Wait() { _event.Wait(); }
        }
        private class C : B
        {
            public void Set() { _event.Set(); }
        }
        public B GetAnInstanceofB() { return new C(); }
        private void DoSomethingWithB(B b) { ((C)b).Set(); }
    }
