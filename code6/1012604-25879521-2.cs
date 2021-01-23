    public class Service {
        public void Fn<T>(T t): where T : I, new() {
            ( new t() ).M();
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
