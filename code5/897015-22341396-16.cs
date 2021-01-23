    public interface IBaseManager<T> {
        ManagedRegister<T> Registered { get; set; }
    }
    public class ConcreteManager : IBaseManager<ConcreteManaged> {
        public ManagedRegister<ConcreteManaged> Registered { get; set; }
        public void Refresh () { Console.WriteLine("Refresh() called"); }
    }
