    public interface IRepository<T>
    {
        T GetById(int id);
    }
    public class Repository<T> : IRepository<T>
    {
        public T GetById(int id)
        {
            Console.WriteLine("Type: " + typeof(T));
            return default(T);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            IRepository<DateTime> iRepository = container.Resolve<IRepository<DateTime>>();
            iRepository.GetById(4);
            Console.ReadLine();
        }
    }
