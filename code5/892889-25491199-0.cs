    public abstract class A
    {
        public abstract int X { get; }
    }
    public class D : A
    {
        private int _x;
        public sealed override int X { get { return XGetterSetter; } }
        public virtual int XGetterSetter { get { return this._x; } set { this._x = value; } }
    }
