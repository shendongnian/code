    public abstract class BaseClass
    {
        public abstract MyObject PropA { get; }
        private MyObject _propB;
        public virtual MyObject PropB
        {
            get { return _propB ?? (_propB = new MyObject()); }
        }
    }
    public class DerivedClass : BaseClass
    {
        // You must provide an implementation here.
        private MyObject _propA;
        public override MyObject PropA
        {
            get { return _propA ?? (_propA = new MyObject()); }
        }
        // You are free to override this property or not.
        public override MyObject PropB
        {
            get
            {
                return base.PropB;
            }
        }
    }
