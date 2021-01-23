    public interface IRepository<T>
    {
        T GetById(int id);
    }
    public class PersonRepository : IRepository<Person>
    {
        public Person GetById(int id)
        {
           var x = context.GetPersonDetails(id);
           return new Person() { 
              // field properties from x
           };
        }
    }
