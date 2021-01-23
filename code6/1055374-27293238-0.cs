    public interface IEntityTask
    {
        string Name { get; }
        void Run();
        object Result { get; }
    }
