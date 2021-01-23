    public class Service {
        public void Fn<T>() where T : I, new() {
            ( new T() ).M();
            // ...
        }
    }
    public interface I
    {
        void M();
    }
    public class C : I
    {
        public void M();
    }
    public class D : I
    {
        public void M();
    }
    static void Main()
    {
        var service = new Service();
        service.Fn<C>();
        service.Fn<D>();
    }
