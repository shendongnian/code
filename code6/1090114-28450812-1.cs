    public abstract class MyBaseClass
    {
        public void Something()
        {
            // Code from SomethingAwesome here, or keep SomethingAwesome
            // separate and call it from here
            SomethingImpl();
        }
        protected abstract void SomethingImpl();
    }
    public class SomeClass : MyBaseClass
    {
        protected override SomethingImpl()
        {
            // Something happens here
        }
    }
