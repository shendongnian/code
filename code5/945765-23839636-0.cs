    public interface IDummy<out T>
    {
        int SomeCommonMethod();
        T Anything { get; }
    }
