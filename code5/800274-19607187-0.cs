    interface IFoo {
        into Value { get; set; }
    }
    public class Foo : IFoo {
        public into Value { get; private set; }
        int IFoo.Value {
            get { return Value; }
            set { Value = value; }
        }
    }
