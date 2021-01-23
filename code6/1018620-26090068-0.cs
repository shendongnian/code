    public class NoWrap
    {
        internal sealed class Wrapped
        {
        }
        public void Wrap()
        {
            this.wrapped = new Wrapped();
        }
        internal Wrapped GetWrapped()     //note: cannot be public
        {
            return wrapped;
        }
        private Wrapped wrapped;
    }
    //...
    NoWrap nw = new NoWrap();  // (*)
    nw.Wrap();                 // (**)
