    public interface IStateObject<T>
    {
        T State { get; set; }
        void Process();
    }
