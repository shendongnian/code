    public sealed class AdHocEquatable<T> : IEquatable<T>
    {
        readonly Func<T, bool> equals;
        public AdHocEquatable(Func<T, bool> eq)
        {
            equals = eq;
        }
        
        public bool Equals(T other)
        {
            return equals(other);
        }
    }
