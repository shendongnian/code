    [ContractClass(typeof(Foo.FooContracts<>))]
    public interface IFoo<T> {
        string Bar(T obj);
    }
    [ContractClassFor(typeof(IFoo<>))]
    public class Foo {
        public class FooContracts<T> : IFoo<T> {
            public string Bar(T obj) {
                throw new NotImplementedException();
            }
        }
    }
