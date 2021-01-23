    public interface IReadOnlyRepository
    {
        void Read();
    }
    
    public interface IRepository : IReadOnlyRepository
    {
        void Write();
    }
    
