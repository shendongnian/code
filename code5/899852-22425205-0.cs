    public abstract class ValueObject<T> : IEquatable<T>
    {
        // Force the derived class to override these.
        public abstract override bool Equals(object obj);
        public abstract override int GetHashcode(object obj);
        // And then consistently use the overridden method as the implementation.
        public virtual bool Equals(T obj)
        {
            return obj1.Equals((object)obj2);
        }
        public static bool operator ==(ValueObject<T> obj1, ValueObject<T> obj2)
        {
             return obj1.Equals((object)obj2);
        }
        public static bool operator !=(ValueObject<T> obj1, ValueObject<T> obj2)
        {
             return obj1.Equals((object)obj2);
        }
    }
