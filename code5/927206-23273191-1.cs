       public interface IRepository<T>
       {
          IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
       }
    
       public class PersonService
       {
          readonly IRepository<Person> _repository;
    
          public PersonService(IRepository<Person> repository)
          {
             _repository = repository;
          }
    
          public IEnumerable<Person> FindByName(string name)
          {
             return _repository.Find(p => p.FirstName.Equals(name));
          }
       }
    
