    public class Foo : IFoo
    {
        public event EventHandler<IBar> MyEvent;
        public void OnMyEvent(IBar bar)
        {
            MyEvent(EventArgs.Empty)
        }
    }
