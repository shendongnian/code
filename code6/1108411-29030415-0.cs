    public abstract class BaseClass
    {
        protected abstract void A();
    }
    public class BaseClassEx
    {
        protected sealed override void A()
        { 
            // action Calling B
        }
        protected virtual void B()
        { 
            // a default action called second
        }
    }
