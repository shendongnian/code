    public interface IAggregate { }
    public class Person : IAggregate { }
    public interface ICommand { }
    public class BaseCommand : ICommand { }
    public interface IUpdateAggregateCommand<out T> : ICommand where T : IAggregate
    {
        T GetEntity();
    }
    public class UpdateAggregateCommand<T> : IUpdateAggregateCommand<T> where T : IAggregate
    {
        private T entity;
        public void SetEntity(T t) { this.entity = t; }
        public T GetEntity() { return this.entity; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var command = new BaseCommand();
            var obj = command as IUpdateAggregateCommand<IAggregate>;
            if (obj != null)
                Console.WriteLine(obj.GetEntity().GetType());
            var command1 = new UpdateAggregateCommand<Person>();
            command1.SetEntity(new Person());
            var obj1 = command1 as IUpdateAggregateCommand<IAggregate>;
            if (obj1 != null)
                Console.WriteLine(obj1.GetEntity().GetType());
        }
    }
