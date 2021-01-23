    public abstract class Summable<T>
    {
        public abstract Summable<T> Add1();
        public abstract Summable<T> Sub1();
        public abstract Summable<T> Zero { get; } //Identity for addition
        public abstract Summable<T> One { get; } //Identity for multiplication
        public abstract bool Equals(Summable<T> other);
        public abstract override string ToString();
        public static Summable<T> Sum(Summable<T> x, Summable<T> y)
        {
            if (y == y.Zero)
                return x;
            if (x == y.Zero)
                return y;
            else
                return Sum(x.Add1(), y.Sub1());
        }
        public static Summable<T> Multiply(Summable<T> x, Summable<T> y)
        {
            //Coming soon...
        }
        public static bool Equal(Summable<T> x, Summable<T> y)
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;
            return x.Equals(y);
        }
        public static bool operator ==(Summable<T> x, Summable<T> y)
        {
            return Equal(x, y);
        }
        public static bool operator !=(Summable<T> x, Summable<T> y)
        {
            return !Equal(x, y);
        }
    }
