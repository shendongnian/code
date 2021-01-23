    public abstract class BaseClass
    {
        // Property not implemented here.
        public abstract MyObject PropA { get; }
        private MyObject _propB;
        // Property implemented, but implementation can be overridden in derived class.
        public virtual MyObject PropB
        {
            get { return _propB ?? (_propB = new MyObject()); }
        }
        public int PropC { get { return 5; } }
    }
    public class DerivedClass : BaseClass
    {
        // You must provide an implementation here.
        private MyObject _propA;
        public override MyObject PropA
        {
            get { return _propA ?? (_propA = new MyObject()); }
        }
        // You are free to override this property and to provide an new implementation
        // or to do nothing here and to keep the original implementation.
        public override MyObject PropB
        {
            get { return <new implementation...>; }
        }
        // PropC is inherited as is and is publicly visible through DerivedClass. 
    }
