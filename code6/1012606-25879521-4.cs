    public class Service {
        public void Fn<T>(): where T : I, new() {
            ( new T() ).M();
            // ...
        }
    }
    public class Main {
        public void main() {
            Service.Fn<C>();
            Service.Fn<D>();
            // ...
        }
    }
