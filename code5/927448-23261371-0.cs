    public interface INameable
    {
        string Name { get; }
    }
    public interface IRepository<T>
    {
        void Add( T obj );
        IEnumerable<T> Values { get; }
    }
    public class Person : INameable
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Car : INameable
    {
        public string Name { get; set; }
        public string Model { get; set; }
    }
    public abstract class AbstractRepository<T> : IRepository<T>
        where T : INameable
    {
        // same as before
        Dictionary<string, object> values = new Dictionary<string, object>();
        void AddValue( INameable o )
        {
            values.Add( o.Name, o );
        }
        IEnumerable<T> ValuesOfType<T>()
        {
            return values.Values.OfType<T>();
        }
        // using generics to implement both the interfaces
        public void Add( T obj ) 
        {
            AddValue( obj );
        }
        public IEnumerable<T> Values 
        {
            get
            {
                return ValuesOfType<T>();
            }
        }
    }
    public class CarRepository : AbstractRepository<Car> { }
    public class PersonRepository : AbstractRepository<Person> { }
