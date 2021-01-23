    public interface IProcessor {
        Foo Foo { get; }
        int Process();
    }
    internal class ImplementedProcessor {
        internal Lazy<Foo> LazyFoo {get;set;}
        public Foo Foo {
            get {
                return LazyFoo.Value;
            }
        }
        public int Process() {
            ...
        }
    }
    public IProcessor CreateProcessor(int fooId) {
        return new ImplementedProcessor {
            LazyFoo = () => this.Context.GetFoo(fooId)
        };
    }
