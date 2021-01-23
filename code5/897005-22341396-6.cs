    public interface IBaseManaged<T> { 
        string Name { get; set; }
        T Manager { get; set; }
    }
    public class ConcreteManaged : IBaseManaged<ConcreteManager> {
        public string Name { get; set; }
        public ConcreteManager Manager { get; set; }
        public void Process ()
        {
            Manager.Refresh ();
        }
    }
