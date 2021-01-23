    public abstract class BaseClass
    {
        public void DoSomething()
        {
            // Base class behaviour goes here.
            DoSomethingInternal();
        }
        protected abstract void DoSomethingInternal();
    }
    public class SubClass : BaseClass
    {
        protected override void DoSomethingInternal()
        {
            // Sub class behaviour goes here.
        }
    }
