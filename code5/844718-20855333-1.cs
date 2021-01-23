    public interface IPeopleRepository
    {
        IEnumerable<Person> Get();
        Person Get(int id);
    }
