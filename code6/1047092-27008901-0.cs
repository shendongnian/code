    public interface IA<T>
    {
        T Item { get; }
    }
    public interface IB<T>
    {
        IA<T> IA { get; }
    }
