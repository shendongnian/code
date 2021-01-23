    class SomeDbContext : DbContext
    {
        public IDbSet<Person> People { get; set; }
    }
    class Person
    {
        public string Foreame { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
    abstract class PersonFilter
    {
        public abstract IQueryable<Person> Filter(IQueryable<Person> query, string value);
    }
    class PersonForenameFilter : PersonFilter
    {
        public override IQueryable<Person> Filter(IQueryable<Person> query, string value)
        {
            return query.Where(t => t.Foreame == value);
        }
    }
    class PersonAgeFilter : PersonFilter
    {
        public override IQueryable<Person> Filter(IQueryable<Person> query, string value)
        {
            return query.Where(t => t.Age.ToString() == value);
        }
    }
