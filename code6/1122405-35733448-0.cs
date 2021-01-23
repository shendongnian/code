    [ContractClass(typeof(ContractClassForIFoo))]
    public interface IFoo
    {
        int DoThing(string x);
    }
    public class Foo : IFoo { ... }
    [ContractClassFor(typeof(IFoo))]
    private abstract class ContractClassForIFoo : IFoo
    {
        public int DoThing(string x)
        {
            Contract.Requires<ArgumentNullException>(x != null);
            throw new NotImplementedException();
        }
    }
