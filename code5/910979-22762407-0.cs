    // Shazaam contract.
    public interface IShazaamInvoker {
        Boolean Shazaam();
    }
    // ShazaamWrapper.v1.dll implementation
    public class ShazaamInvoker : IShazaamInvoker {
        public void Shazaam() {
            Int32 param = 42;
            return UseThisMethodSignature(param);
        }
    }
    // ShazaamWrapper.v2.dll implementation
    public class ShazaamInvoker : IShazaamInvoker {
        public void Shazaam() {
            Single param = 42f;
            return UseOtherMethodSignature(param);
        }
    }
    // Determine, at runtime, which wrapper to use.
    var invoker = (IShazaamInvoker)(/*HereBeMagicResolving*/)
    invoker.Shazaam();
