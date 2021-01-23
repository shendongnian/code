    public interface IRepository<T>
    {
        T GetById(object id);
        void Add(T entity);
        // ...
    }
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPeopleByDepartment(int id);
    }
