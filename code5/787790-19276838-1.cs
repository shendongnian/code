    public class Foo : MarshalByRefObject {
        public Foo() {
            AppDomain.CurrentDomain.FirstChanceException += (s, e) => {
                Debug.WriteLine("* " + e.Exception.Message);
            };
        }
        // etc...
    }
