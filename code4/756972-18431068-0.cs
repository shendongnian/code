    public class ClassA
    {
        private ReferenceClassB reference;
        public ClassA()
        {
            reference = new ReferenceClassB(this);
        }
    }
    public class ReferenceClassB
    {
        private ClassA referencedClass;
        public ReferenceClassB(ClassA reference)
        {
            referencedClass = reference;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ClassA a = new ClassA();
            ReferenceClassB b = (ReferenceClassB) a.GetType().GetField("reference", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(a);
            WeakReference weakA = new WeakReference(a);
            WeakReference weakB = new WeakReference(b);
            a = null;
            b = null;
            GC.Collect();
            Debug.Assert(weakA.IsAlive==false);
            Debug.Assert(weakB.IsAlive==false);
        }
    }
