    public interface IMonoid<T>
    {
        T Combine(T x, T y);
        T Identity { get; }
    }
