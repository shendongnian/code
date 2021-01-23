    public abstract class AbsClass1
    {
        // non-abstract deriving class MUST override this
        public abstract str1 Headers { get; }
    }
    public class Class1
    {
        // deriving class may override, but doesn't have to
        public virtual str1 Headers { get { return headers; } }
    }
