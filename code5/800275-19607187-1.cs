    interface IFoo {
        int Value { get; set; }
    }
    public class Foo : IFoo {
        public int Value { get; private set; }
        int IFoo.Value {
            get { return Value; }
            set { Value = value; }
        }
    }
