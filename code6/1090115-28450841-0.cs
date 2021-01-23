    public class MyBaseClass
    {
        public void SomethingAwesome()
        {
             // ...
        }
        public void Something()
        {
             SomethingImpl();
             SomethingAwesome();
        }
        protected abstract void SomethingImpl();
    }
