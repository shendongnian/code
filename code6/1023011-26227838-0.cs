    public interface IMyClassRepository<T> where T : MyBaseClass
    {
        T Get(int id);
        void Create(T param);
        void Update(T param);
    }
